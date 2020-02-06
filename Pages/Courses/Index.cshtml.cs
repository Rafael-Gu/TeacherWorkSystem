using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeacherWork.Data;
using TeacherWork.Models;

namespace TeacherWork.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly TeacherWorkContext _context;

        public IndexModel(TeacherWorkContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get; set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Course
                .Include(c => c.Subject)
                .Include(c => c.Teacher).ToListAsync();
        }
    }
}
