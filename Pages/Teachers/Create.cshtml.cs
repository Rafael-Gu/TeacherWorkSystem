using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TeacherWork.Models;

namespace TeacherWork.Pages.Teachers
{
	public class CreateModel : PageModel
	{
		private readonly Data.TeacherWorkContext _context;

		public CreateModel(Data.TeacherWorkContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Teacher Teacher { get; set; }

		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Teacher.Add(Teacher);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
