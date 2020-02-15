using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TeacherWork.Services
{
	public interface IDataProcessService
	{
		public Data.TeacherWorkContext Context { get; set; }
		public void ImportFromExcel(string filename);
		public void Process();
		public List<ICourseService> GetCourseStat();

	}
}
