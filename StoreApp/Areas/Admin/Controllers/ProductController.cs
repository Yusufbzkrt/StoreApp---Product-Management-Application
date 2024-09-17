using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
			ViewBag.Categories = GetCategoriesSelectList();
				return View();
		}

		private SelectList GetCategoriesSelectList()
		{
			return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1"); //kategori lisesine erişim sağlandı. 1 ile belirtilen yer default değerdir.

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
		{
			if (ModelState.IsValid)
			{
				_manager.ProductService.CreateProduct(productDto);
				return RedirectToAction("Index");
			}
			return View();
		}
		public ActionResult Update([FromRoute(Name = "id")] int id)//route den gelen id yi al
		{
			ViewBag.Categories = GetCategoriesSelectList();
			var model = _manager.ProductService.GetOneProductForUpdate(id, false);//sadece bu satırla update sayfasına giderken düzenlenecek bilgileri formlara doldurduk. 
			return View(model);
		}

		[HttpPost]
		public ActionResult Update([FromForm] ProductDtoForUpdate product)
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

