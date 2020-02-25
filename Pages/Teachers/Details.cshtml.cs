using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using TeacherWork.Models;

namespace TeacherWork.Pages.Teachers
{
	public class DetailsModel : PageModel
	{
		private readonly Data.TeacherWorkContext _context;

		public DetailsModel(Data.TeacherWorkContext context)
		{
			_context = context;
		}

		public Teacher Teacher { get; set; }

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Teacher = await _context.Teacher.FirstOrDefaultAsync(m => m.Id == id);
			Teacher.Courses = await _context.Course.Include(c=>c.Subject).Where(c => c.TeacherID == Teacher.Id).ToListAsync();
				/*(from c in _context.Course
				 where c.TeacherID == Teacher.Id
				 select c).ToListAsync();*/
			if (Teacher == null)
			{
				return NotFound();
			}
			return Page();
		}
	}
}
