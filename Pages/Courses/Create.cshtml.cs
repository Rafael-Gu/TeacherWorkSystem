﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using TeacherWork.Data;
using TeacherWork.Models;

namespace TeacherWork.Pages.Courses
{
	public class CreateModel : PageModel
	{
		private readonly TeacherWorkContext _context;

		public CreateModel(TeacherWorkContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			ViewData["SubjectID"] = new SelectList(_context.Subject, "Id", "Id");
			ViewData["TeacherID"] = new SelectList(_context.Teacher, "Id", "IdName");
			return Page();
		}

		[BindProperty]
		public Course Course { get; set; }

		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Course.Add(Course);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
