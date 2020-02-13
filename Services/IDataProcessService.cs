using System.Collections.Generic;

namespace TeacherWork.Services
{
	public interface IDataProcessService
	{
		public void ImportFromExcel(string filename);
		public void Process();
		public List<ICourseService> GetCourseStat();

	}
}
