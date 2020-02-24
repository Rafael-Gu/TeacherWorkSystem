using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TeacherWork.Data;
using TeacherWork.Models;

namespace TeacherWork.Pages.Courses
{
	public class EditModel : PageModel
	{
		private readonly TeacherWorkContext _context;

		public EditModel(TeacherWorkContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Course Course { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Course = await _context.Course
				.Include(c => c.Subject)
				.Include(c => c.Teacher).FirstOrDefaultAsync(m => m.Id == id);

			if (Course == null)
			{
				return NotFound();
			}
			ViewData["SubjectID"] = new SelectList(_context.Subject, "Id", "IdName");
			ViewData["TeacherID"] = new SelectList(_context.Teacher, "Id", "IdName");
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

			_context.Attach(Course).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CourseExists(Course.Id))
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

		private bool CourseExists(int id)
		{
			return _context.Course.Any(e => e.Id == id);
		}
	}
}
