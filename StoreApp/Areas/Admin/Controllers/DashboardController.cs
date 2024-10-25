using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers//arealar ile çalıştığımız zaman controllerın başına hangi areayı kullandığımızı belirtmemiz gerekiyor.
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class DashboardController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;

		public DashboardController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			TempData["info"] = $"Welcome back, {user.UserName}";
			return View();
		}
	}
}
