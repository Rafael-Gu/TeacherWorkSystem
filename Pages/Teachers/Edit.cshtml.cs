using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TeacherWork.Models;

namespace TeacherWork.Pages.Teachers
{
	public class EditModel : PageModel
	{
		private readonly Data.TeacherWorkContext _context;

		public EditModel(Data.TeacherWorkContext context)
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

		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Teacher).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TeacherExists(Teacher.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool TeacherExists(string id)
		{
			return _context.Teacher.Any(e => e.Id == id);
		}
	}
}
