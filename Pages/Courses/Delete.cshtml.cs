﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TeacherWork.Data;
using TeacherWork.Models;

namespace TeacherWork.Pages.Courses
{
	public class DeleteModel : PageModel
	{
		private readonly TeacherWorkContext _context;

		public DeleteModel(TeacherWorkContext context)
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
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Course = await _context.Course.FindAsync(id);

			if (Course != null)
			{
				_context.Course.Remove(Course);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
