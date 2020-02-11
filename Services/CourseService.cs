using System;
using System.Collections.Generic;
using System.Data;
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
				if(Course.Assessment == AssessmentType.Examination)
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

		public decimal K3
		{
			get
			{
				return Course.IsSQE ? 0.2M : 0.0M;
			}
		}

		public decimal G
		{
			get
			{
				return Jz * 1.02M * (0.5M + (N_ - 15) * 0.03M) * (1 + K2 + K3) * Cx * N / N_;
			}
		}

		public decimal Jz
		{
			get
			{
				return Course.Task.Name == "上机" ? Course.PeriodTsk : Course.PeriodThr;
			}
		}

		public decimal Cx
		{
			get
			{
				return 1.0M;
			}
		}

		public decimal MajorWork
		{
			get
			{	
				return K0 * Course.Count * Course.PeriodTsk * K1 * (1.0M+K2+K3);
			}
		}

		public decimal N
		{
			get
			{
				return Course.Count;
			}
		}

		public decimal N_
		{
			get
			{
				return 15M;
			}
		}
	}
}
