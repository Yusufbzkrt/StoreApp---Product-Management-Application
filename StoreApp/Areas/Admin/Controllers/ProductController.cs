using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IServiceManager _manager;

		public ProductController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var model = _manager.ProductService.GetAllProducts(false);
			return View(model);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] Product product)
		{
			if (ModelState.IsValid)
			{
				_manager.ProductService.CreateProduct(product);
				return RedirectToAction("Index");
			}
			return View();
		}
		public ActionResult Update([FromRoute(Name = "id")] int id)//route den gelen id yi al
		{
			var model = _manager.ProductService.GetOneProduct(id, false);//sadece bu satırla update sayfasına giderken düzenlenecek bilgileri formlara doldurduk. 
			return View(model);
		}

		[HttpPost]
		public ActionResult Update(Product product)
		{
			if (ModelState.IsValid)
			{
				_manager.ProductService.UpdateOneProduct(product);
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Delete([FromRoute(Name = "id")] int id)
		{
			_manager.ProductService.DeleteOneProduct(id);
			return RedirectToAction("Index");
		}
	}
}

