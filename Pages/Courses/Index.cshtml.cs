using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TeacherWork.Models;
using Task = System.Threading.Tasks.Task;

namespace TeacherWork
{
	public class IndexModel : PageModel
	{
		private readonly TeacherWork.Data.TeacherWorkContext _context;

		public IndexModel(TeacherWork.Data.TeacherWorkContext context)
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
