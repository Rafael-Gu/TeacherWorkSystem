using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TeacherWork.Models
{

    public class Teacher
    {
        [Key, RegularExpression(@"^[0-9]+$",ErrorMessage = "要求为全数字"), Required(ErrorMessage = "{0}是必填的！")]//模式匹配，只匹配全数字
        [Display(Name = "教工编号")]
        public string Id { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        [Display(Name = "教师姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}是必填的！")]
        [Display(Name = "所属部门")]
        public string Department { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "{0}是必填的！")]
        [Display(Name = "出生日期")]
        public DateTime Birth { get; set; }

        [Display(Name = "职称")]
        public string Rank { get; set; }

        public List<Course> Courses { get; set; }

        public string IdName
        {
            get
            {
                return $"{Name}/{Id}";
            }
        }
    }
}
