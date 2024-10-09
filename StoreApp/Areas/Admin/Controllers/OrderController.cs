﻿using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{

	[Area("Admin")]//arelarla çalışıldığı zaman bu controllerın hangi area altında çalışacağını belirtmemiz lazım.
	public class OrderController : Controller
	{
		private readonly IServiceManager _manager;

		public OrderController(IServiceManager manager)
		{
			_manager = manager;
		}

		public ActionResult Index()
		{
			var orders = _manager.OrderService.Orders;
			return View(orders);
		}

		[HttpPost]
		public IActionResult Complete([FromForm] int id)
		{
			_manager.OrderService.Complete(id);
			return RedirectToAction("Index");
		}
	}
}