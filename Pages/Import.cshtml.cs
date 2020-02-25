using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TeacherWork.Services;

namespace TeacherWork.Pages
{
	public class ImportModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly TeacherWork.Data.TeacherWorkContext _context;

		public ImportModel(ILogger<IndexModel> logger,TeacherWork.Data.TeacherWorkContext context)
		{
			_logger = logger;
			_context = context;
		}

		public void OnGet()
		{

		}

		public IActionResult OnPost()
		{
			DataProcessService dps = new DataProcessService();
			dps.Context = _context;
			dps.ImportFromExcel(@"input.xls");
			return RedirectToPage(@"/Index");
		}


	}
}
