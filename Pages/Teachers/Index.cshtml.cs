using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherWork.Models;
using Task = System.Threading.Tasks.Task;

namespace TeacherWork.Pages.Teachers
{
	public class IndexModel : PageModel
	{
		private readonly TeacherWork.Data.TeacherWorkContext _context;

		public IndexModel(TeacherWork.Data.TeacherWorkContext context)
		{
			_context = context;
		}

		public IList<Teacher> Teacher { get; set; }

		public async Task OnGetAsync()
		{
			Teacher = await _context.Teacher.ToListAsync();
		}
	}
}
