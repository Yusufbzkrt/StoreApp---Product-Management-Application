﻿using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers//arealar ile çalıştığımız zaman controllerın başına hangi areayı kullandığımızı belirtmemiz gerekiyor.
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}