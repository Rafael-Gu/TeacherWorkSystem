using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TeacherWork.Models
{
    public class Class
    {
        [Required]
        [Display(Name = "专业名称")]
        public string Profession { get; set; }

        [Required]
        [Display(Name = "班级号")]
        public string Index { get; set; }
    }
}
