using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using StoreApp.Models;

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

		public IActionResult Index([FromQuery] ProductRequestParameters p)
		{
			ViewData["Title"] = "Products";
			var products = _manager.ProductService.GetAllProductsWithDetails(p);
			var pagination = new Pagination()
			{
				CurrenPage = p.PageNumber,
				ItemsPerPage = p.PageSize,
				TotalItems = _manager.ProductService.GetAllProducts(false).Count()
			};
			return View(new ProductListViewModel()
			{
				Products = products,
				Pagination = pagination
			});
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
				TempData["success"] = $"<strong>{productDto.ProductName}</strong> has been created";
				return RedirectToAction("Index");
			}
			return View();
		}// resim yüklemek için  IFormFile file eklendi 42-49 arası resim dosyasını kaydetmek için
		public ActionResult Update([FromRoute(Name = "id")] int id)//route den gelen id yi al
		{
			ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id, false);//sadece bu satırla update sayfasına giderken düzenlenecek bilgileri formlara doldurduk. 
            ViewData["Title"] = model?.ProductName;
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
			var product = _manager.ProductService.GetOneProduct(id,false);
			_manager.ProductService.DeleteOneProduct(id);
			TempData["danger"] = $"<strong>{product.ProductName}</strong> has been <strong>removed</strong>";
			return RedirectToAction("Index");
		}
	}
}

