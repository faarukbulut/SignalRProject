using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

		[HttpPost]
		public async Task<IActionResult> Index(UserEditDto userEditDto)
		{
			if(userEditDto.Password == userEditDto.Password2)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.Name = userEditDto.Name;
				user.Surname = userEditDto.Surname;
				user.Email = userEditDto.Mail;
				user.UserName = userEditDto.Username;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);

				var result = await _userManager.UpdateAsync(user);
				return RedirectToAction("Index");
			}

			return View();
		}
	}
}
