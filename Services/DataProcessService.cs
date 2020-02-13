using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
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
}
