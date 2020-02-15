using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TeacherWork.Models;

namespace TeacherWork.Pages.Teachers
{
	public class DeleteModel : PageModel
	{
		private readonly Data.TeacherWorkContext _context;

		public DeleteModel(Data.TeacherWorkContext context)
		{
			_context = context;
		}

		[BindProperty]
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

		public async Task<IActionResult> OnPostAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Teacher = await _context.Teacher.FindAsync(id);

			if (Teacher != null)
			{
				_context.Teacher.Remove(Teacher);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
