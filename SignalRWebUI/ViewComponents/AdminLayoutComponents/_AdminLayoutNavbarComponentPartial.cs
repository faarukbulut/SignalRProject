using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
