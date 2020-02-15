using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using TeacherWork.Data;
using TeacherWork.Models;


namespace TeacherWork.Services
{
	public class DataProcessService : IDataProcessService
	{

		private List<Teacher> teachers;
		private List<Course> courses;
		private List<Subject> subjects;
		private List<Task> tasks;

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
				ISheet worksheet = workbook.GetSheet("主修课程");

				ImportingEntry ientry = new ImportingEntry();
				worksheet.RemoveRow(worksheet.GetRow(0));
				foreach(IRow row in worksheet)
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
						SubjectID = ientry.Subject.Id,
						Credit = decimal.Parse(row.GetCell(7).ToString()),
						
					};
					
					
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
		public HashSet<Task> Tasks { get; set; }
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
			foreach(var task in Tasks)
			{
				context.Add(task);
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
		public Task Task { get; set; }
		public Course Course { get; set; }

		public void Involve(ImportedData idata)
		{
			idata.Teachers.Add(Teacher);
			
		}
	}
}
