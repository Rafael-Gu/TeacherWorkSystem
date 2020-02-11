using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherWork.Models;

namespace TeacherWork.Services
{
	public interface ICourseService
	{
		public decimal K0 { get; }
		public decimal K1 { get; }
		public decimal K2 { get; }
		public decimal K3 { get; }

		public decimal MajorWork { get; }
		
		public decimal G { get; }
		public decimal Jz { get; }
		public decimal Cx { get; }
		public decimal N { get; }
		public decimal N_ { get; }


	}
}
