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

		public List<Course> Courses { get; set; }
	}
}
