using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TeacherWork.Data;
using TeacherWork.Models;


namespace TeacherWork.Services
{
	public class DataProcessService : IDataProcessService
	{

		private List<Teacher> teachers;
		private List<Course> courses;
		private List<Subject> subjects;

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
						Rank = ""
					};
					ientry.Subject = new Subject()
					{
						Id = row.GetCell(4).ToString(),
						Name = row.GetCell(5).ToString(),
						Department = row.GetCell(3).ToString(),
					};
					ientry.Course = new Course()
					{
						TeacherID = ientry.Teacher.Id,
						Teacher = ientry.Teacher,
						SubjectID = ientry.Subject.Id,
						Subject = ientry.Subject,
						Credit = decimal.Parse(row.GetCell(7).ToString()),
						Semester = int.Parse(row.GetCell(1).ToString()),
						Assessment = row.GetCell(20).ToString() switch { "考试" => AssessmentType.Examination, _ => AssessmentType.Checking },
						Type = row.GetCell(2).ToString(),
						Count = int.Parse(row.GetCell(10).ToString()),
						StartYear = int.Parse(row.GetCell(0).ToString().Split('-')[0]),
						EndYear = int.Parse(row.GetCell(0).ToString().Split('-')[1]),
						IsNew = false,
						IsSQE = false,
					};
					

					ientry.RollInto(idata);
				}
				
				sheet = workbook.GetSheet("新开课");
				sheet.RemoveRow(sheet.GetRow(0));
				foreach(IRow row in sheet)
				{
					var query =
						from c in idata.Courses
						where c.Subject.Name == row.GetCell(2).ToString() && c.Teacher.Name == row.GetCell(3).ToString() && c.Subject.Department == row.GetCell(1).ToString()
						select c;
					foreach(var q in query)
					{
						q.IsNew = true;
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
							from crs in idata.Courses 
							where crs.Subject.Name == c.ToString() 
							select crs;
						foreach (var q in query)
						{
							q.IsSQE = true;
						}
					}
				}
			}
			catch (FileNotFoundException)
			{
				throw;
			}
			catch (FormatException)
			{
				Console.WriteLine("数据异常");
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

		public void Import(TeacherWorkContext context)
		{
			foreach(var teacher in Teachers)
			{
				context.Add(teacher);
			}
			foreach(var subject in Subjects)
			{
				context.Add(subject);
			}
			foreach(var course in Courses)
			{
				context.Add(course);
			}
			context.SaveChanges();
		}
	}

	internal class ImportingEntry
	{
		public Teacher Teacher { get; set; }
		public Subject Subject { get; set; }
		public Course Course { get; set; }

		public void RollInto(ImportedData idata)
		{
			idata.Teachers.Add(Teacher);
		}
	}
}
