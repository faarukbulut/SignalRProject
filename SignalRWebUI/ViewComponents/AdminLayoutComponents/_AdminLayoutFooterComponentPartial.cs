using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutFooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
