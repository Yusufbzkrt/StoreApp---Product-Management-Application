using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using Repositories;

namespace StoreApp.Controllers
{
	public class ProductController : Controller
	{
		private readonly RepositoryContext _Context;//9-15 arası anlatılmak istenilen, repositorycontext görüldüğü anda bağlantı dizesi direk oluşturulsun ve kullanabileceğim bir context ifadesi versin.

		public ProductController(RepositoryContext context)
		{
			_Context = context;
		}

		public IActionResult Index()
		{
			var model = _Context.Products.ToList();
			return View(model);
		}

		public IActionResult Get(int id)
		{
			var model = _Context.Products.FirstOrDefault(p=> p.ProductId.Equals(id));
			return View(model);
		} 
	}
}
