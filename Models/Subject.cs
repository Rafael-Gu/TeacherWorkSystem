using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeacherWork.Models
{
	public class Subject
	{

		[Key, RegularExpression(@"^[0-9]+$", ErrorMessage = "要求为全数字")]
		[Display(Name = "课程编号")]
		public string Id { get; set; }
		[Required]
		[Display(Name = "课程名称")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "所属部门")]
		public string Department { get; set; }

		public IEnumerable<Course> Courses { get; set; }

		public string IdName
		{
			get
			{
				return $"{Id}/{Name}";
			}
		}

		//public static bool operator ==(Subject s1,Subject s2)
		//{
		//	if (s1 is null || s2 is null)
		//		return !(s1 is null ^ s2 is null);
		//	else
		//		return s1.Id == s2.Id && s1.Name == s2.Name;
		//}
		//public static bool operator !=(Subject s1,Subject s2)
		//{
		//	return !(s1 == s2);
		//}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
