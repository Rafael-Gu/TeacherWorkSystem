using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherWork.Models;

namespace TeacherWork.Services
{
	public class CourseService : ICourseService
	{


		public Teacher Teacher
		{
			get
			{
				return Course.Teacher;
			}
		}

		public Course Course { get; set; }

		public decimal K0
		{
			get
			{
				return 1.0M;
			}
		}

		public decimal K1
		{
			get
			{
				if(Course.Count < 30)
				{
					return 1.0M;
				}
				else
				{
					return 1.0M + (Course.Count - 30.0M) * 0.01M;
				}
			}
		}

		public decimal K2
		{
			get
			{
				if(Course.ExamType == "考试")
				{
					if (Course.Attribute == "专业选修课")
						return 0.15M;
					else
						return 0.10M;
				}
				else
				{
					return 0.15M;
				}
			}
		}

		public decimal K3 => throw new NotImplementedException();

		public decimal G => throw new NotImplementedException();

		public decimal Jz => throw new NotImplementedException();

		public decimal Cx => throw new NotImplementedException();
	}
}
