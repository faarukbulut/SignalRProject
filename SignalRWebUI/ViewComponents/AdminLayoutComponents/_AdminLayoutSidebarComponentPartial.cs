using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutSidebarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
