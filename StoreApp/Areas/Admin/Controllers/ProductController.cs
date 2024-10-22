using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
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
		public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
		{
			if (ModelState.IsValid)
			{
				//file operation 
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img",file.FileName);
				
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				productDto.ImageUrl = String.Concat("/img/",file.FileName);
				
				_manager.ProductService.CreateProduct(productDto);
				return RedirectToAction("Index");
			}
			return View();
		}// resim yüklemek için  IFormFile file eklendi 42-49 arası resim dosyasını kaydetmek için
		public ActionResult Update([FromRoute(Name = "id")] int id)//route den gelen id yi al
		{
			ViewBag.Categories = GetCategoriesSelectList();
			var model = _manager.ProductService.GetOneProductForUpdate(id, false);//sadece bu satırla update sayfasına giderken düzenlenecek bilgileri formlara doldurduk. 
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
		{
			if (ModelState.IsValid)
			{
				//file operation 
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);

				using (var stream = new FileStream(path, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				productDto.ImageUrl = String.Concat("/img/", file.FileName);
				_manager.ProductService.UpdateOneProduct(productDto);
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

