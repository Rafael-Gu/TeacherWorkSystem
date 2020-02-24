using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TeacherWork.Data;
using TeacherWork.Models;
using TeacherWork.Utilities;


namespace TeacherWork.Services
{
	public class DataProcessService : IDataProcessService
	{

		private IWorkbook workbook = null;

		public TeacherWorkContext Context { get; set; }

		public List<ICourseService> GetCourseStat()
		{
			throw new NotImplementedException();
		}

		public void ImportFromExcel(string filename)
		{
			try
			{
				workbook = new HSSFWorkbook(new FileStream(filename, FileMode.Open));
				ISheet sheet = workbook.GetSheet("主修课程");

				ImportingEntry ientry = new ImportingEntry();
				ImportedData idata = new ImportedData();

				sheet.RemoveRow(sheet.GetRow(0));

				foreach(IRow row in sheet)
				{
					ientry.Teacher = new Teacher()
					{
						Id = row.GetCell(12).ToString(),
						Name = row.GetCell(13).ToString(),
						Department = row.GetCell(11).ToString(),
					};
					ientry.Subject = new Subject()
					{
						Id = row.GetCell(4).ToString(),
						Name = row.GetCell(5).ToString(),
						Department = row.GetCell(3).ToString(),
					};
					ientry.Course = new Course();

					{
						ientry.Course.TeacherID = ientry.Teacher.Id;
						//ientry.Course.Teacher = ientry.Teacher;
						ientry.Course.SubjectID = ientry.Subject.Id;
						//ientry.Course.Subject = ientry.Subject;
						ientry.Course.Credit = decimal.Parse(row.GetCell(9).ToString());
						ientry.Course.Semester = int.Parse(row.GetCell(1).ToString());
						ientry.Course.Assessment = row.GetCell(20).ToString() switch { "考试" => AssessmentType.Examination, _ => AssessmentType.Checking };
						ientry.Course.Type = row.GetCell(2).ToString();
						ientry.Course.Count = int.Parse(row.GetCell(10).ToString());
						ientry.Course.StartYear = int.Parse(row.GetCell(0).ToString().Split('-')[0]);
						ientry.Course.EndYear = int.Parse(row.GetCell(0).ToString().Split('-')[1]);
						ientry.Course.IsNew = false;
						ientry.Course.IsSQE = false;
						ientry.Course.Attribute = row.GetCell(16).ToString();
						ientry.Course.PeriodExp = StringUtility.ParsePeriod(row.GetCell(8).ToString());
						ientry.Course.PeriodThr = StringUtility.ParsePeriod(row.GetCell(7).ToString());
						ientry.Course.PeriodTsk = StringUtility.ParsePeriod(row.GetCell(15).ToString());//string.IsNullOrEmpty(row.GetCell(7).ToString()) ? 0 : int.Parse(row.GetCell(7).ToString()),
						ientry.Course.Task = row.GetCell(14).ToString();
					};

					var course = ientry.Course;
					switch(course.Task)
					{
						case "理论学时":
							course.Attribute = "主讲";
							break;
						case "单列实践":
							course.Attribute = "实践";
							break;
						default:
							break;
					}
					
					if(course.PeriodExp != 0)
					{
						course.Task = "实验学时";
						course.Attribute = "上机";
					}

					ientry.RollInto(idata);
				}

				idata.Import(Context);

				sheet = workbook.GetSheet("新开课");
				sheet.RemoveRow(sheet.GetRow(0));
				foreach(IRow row in sheet)
				{
					var query =
						from c in Context.Course
						where c.Subject.Name == row.GetCell(2).ToString() && c.Teacher.Name == row.GetCell(3).ToString() && c.Subject.Department == row.GetCell(1).ToString()
						select c;
					foreach(var q in query)
					{
						q.IsNew = true;
						Context.Course.Update(q);
					}
				}

				sheet = workbook.GetSheet("校级教学质量工程");
				List<string> sqelist = new List<string>();
				foreach (IRow row in sheet)
				{
					row.RemoveCell(row.GetCell(0));
					foreach (ICell c in row)
					{
						var query =
							from crs in idata.Courses.ToHashSet() 
							where crs.Subject.Name == c.ToString() 
							select crs;
						foreach (var q in query)
						{
							q.IsSQE = true;
							Context.Course.Update(q);
						}
					}
				}
				Context.SaveChanges();
				
			}
			catch (FileNotFoundException)
			{
				throw;
			}
		}

		public void Process()
		{
			if (workbook == null)
				return;
		}
	}

	internal class ImportedData
	{
		public HashSet<Teacher> Teachers { get; set; }
		public HashSet<Subject> Subjects { get; set; }
		public HashSet<Course> Courses { get; set; }

		public ImportedData()
		{
			Teachers = new HashSet<Teacher>(new Utilities.TeacherComparer());
			Subjects = new HashSet<Subject>(new Utilities.SubjectComparer());
			Courses = new HashSet<Course>();
		}

		public void Import(TeacherWorkContext context)
		{
			//context.Teacher.Union(Teachers.ToHashSet());
			//context.Subject.Union(Subjects.ToHashSet());
			//context.Course.Union(Courses.ToHashSet());
			context.Teacher.AddRange(Teachers);
			context.Subject.AddRange(Subjects);
			context.Course.AddRange(Courses);
			context.SaveChanges();
			//foreach (var subject in Subjects)
			//{
			//	if (!context.Subject.Any(s => s.Id == subject.Id))
			//		context.Subject.Add(subject);
			//}
			//context.SaveChanges();
			//foreach (var course in Courses)
			//{
			//	context.Course.Add(course);
			//}
			//context.SaveChanges();
		}
	}

	internal class ImportingEntry
	{
		public Teacher Teacher { get; set; }
		public Subject Subject { get; set; }
		public Course Course { get; set; }

		public void RollInto(ImportedData idata)
		{
			if(Teacher != null)
				idata.Teachers.Add(Teacher);
			if (Subject != null)
				idata.Subjects.Add(Subject);
			if (Course != null)
				idata.Courses.Add(Course);
		}
	}
}