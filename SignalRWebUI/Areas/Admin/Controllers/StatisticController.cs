using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
