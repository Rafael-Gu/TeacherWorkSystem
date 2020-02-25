using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TeacherWork.Data;
using TeacherWork.Models;
using TeacherWork.Services;

namespace TeacherWork.Pages.Courses
{
	public class DetailsModel : PageModel
	{
		private readonly TeacherWorkContext _context;
		public Course Course { get; set; }
		public ICourseService CourseService { get; }

		public DetailsModel(TeacherWorkContext context,ICourseService courseService)
		{
			_context = context;
			CourseService = courseService;
		}

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Course = await _context.Course
				.Include(c => c.Subject)
				.Include(c => c.Teacher).FirstOrDefaultAsync(m => m.Id == id);
			(CourseService as CourseService).Course = Course;

			if (Course == null)
			{
				return NotFound();
			}
			return Page();
		}
	}
}
