using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
	public class SettingController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public SettingController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);

			UserEditDto userEditDto = new UserEditDto();
			userEditDto.Mail = value.Email;
			userEditDto.Name = value.Name;
			userEditDto.Surname = value.Surname;
			userEditDto.Username = value.UserName;

			return View(userEditDto);
		}
	}
}
