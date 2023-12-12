using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutHeaderComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
