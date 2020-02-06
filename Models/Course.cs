using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeacherWork.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}是必填的")]
        public string SubjectID { get; set; }
        public Subject Subject { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public string TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public int StartYear { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public int EndYear { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public string Type { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public decimal Credit { get; set; }//定点小数类型

        [Required(ErrorMessage = "{0}是必填的！")]
        public int PeriodThr { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public int PeriodExp { get; set; }

        public int PeriodCrs //
        {
            get
            {
                return PeriodExp + PeriodThr;
            }
        }

        [Required(ErrorMessage = "{0}是必填的！")]
        public int CountNormal { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public int CountNonRetake { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        public int Count { get; set; }

        public bool IsNew { get; set; }

        public string ExamType { get; set; }


    }
}
