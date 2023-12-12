using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
