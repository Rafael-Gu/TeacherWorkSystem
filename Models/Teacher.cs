using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeacherWork.Models
{

	public class Teacher
	{
		[Key, RegularExpression(@"^[0-9]+$", ErrorMessage = "要求为全数字"), Required(ErrorMessage = "{0}是必填的！")]//模式匹配，只匹配全数字
		[Display(Name = "教工编号")]
		public string Id { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "教师姓名")]
		public string Name { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "所属部门")]
		public string Department { get; set; }

		public IEnumerable<Course> Courses { get; set; }

		public string IdName
		{
			get
			{
				return $"{Name}/{Id}";
			}
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		//public override bool Equals(object obj)
		//{
		//	if (obj is Teacher t)
		//		return Id == t.Id && Name == t.Name;
		//	else
		//		return false;
		//}
		//
		//public static bool operator ==(Teacher t1,Teacher t2)
		//{
		//	if(t1 is null || t2 is null)
		//	{
		//		return !(t1 is null ^ t2 is null);
		//	}
		//	else
		//	{
		//		return t1.Id == t2.Id && t1.Name == t2.Name;
		//	}
		//}
		//public static bool operator !=(Teacher t1,Teacher t2)
		//{
		//	return !(t1 == t2);
		//}

	}
}
