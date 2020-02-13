using System.ComponentModel.DataAnnotations;

namespace TeacherWork.Models
{
	public class Course
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "{0}是必填的")]
		[Display(Name = "课程")]
		public string SubjectID { get; set; }
		public Subject Subject { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "教师")]
		public string TeacherID { get; set; }
		public Teacher Teacher { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "起始年")]
		public int StartYear { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "结束年")]
		public int EndYear { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "学期")]
		public int Semester { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "开课类别")]
		public string Type { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "学分")]
		public decimal Credit { get; set; }//定点小数类型

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "理论学时")]
		public int PeriodThr { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "实验学时")]
		public int PeriodExp { get; set; }

		public int PeriodCrs //
		{
			get
			{
				return PeriodExp + PeriodThr;
			}
		}

		[Required(ErrorMessage = "{0}是必填的")]
		[Display(Name = "任务类型")]
		public int TaskId { get; set; }
		public Task Task { get; set; }

		[Display(Name = "任务学时")]
		public int PeriodTsk { get; set; }


		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "正常选课人数")]
		public int CountNormal { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "非重修选课人数")]
		public int CountNonRetake { get; set; }

		[Required(ErrorMessage = "{0}是必填的！")]
		[Display(Name = "选课总人数")]
		public int Count { get; set; }

		[Display(Name = "新开课")]
		public bool IsNew { get; set; }

		[Display(Name = "考核方式")]
		public AssessmentType Assessment { get; set; }

		[Display(Name = "课程性质")]
		public string Attribute { get; set; }

		[Display(Name = "校级质量工程")]
		public bool IsSQE { get; set; }
	}

	public enum AssessmentType
	{
		[Display(Name = "考试")]
		Examination,
		[Display(Name = "考查")]
		Checking,
	}
}
