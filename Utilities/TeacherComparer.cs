using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using TeacherWork.Models;

namespace TeacherWork.Utilities
{
	public class TeacherComparer : IEqualityComparer<Teacher>
	{
		public bool Equals([AllowNull] Teacher x, [AllowNull] Teacher y)
		{
			return x.Id == y.Id;
		}

		public int GetHashCode([DisallowNull] Teacher obj)
		{
			return obj.Id.GetHashCode();
		}
	}

	public class SubjectComparer : IEqualityComparer<Subject>
	{
		public bool Equals([AllowNull] Subject x, [AllowNull] Subject y)
		{
			return x.Id == y.Id;
		}

		public int GetHashCode([DisallowNull] Subject obj)
		{
			return obj.Id.GetHashCode();
		}
	}
}
