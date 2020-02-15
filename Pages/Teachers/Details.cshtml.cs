using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

			if (Teacher == null)
			{
				return NotFound();
			}
			return Page();
		}
	}
}
