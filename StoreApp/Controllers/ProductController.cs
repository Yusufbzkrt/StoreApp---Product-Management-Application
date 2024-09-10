using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
	public class ProductController : Controller
	{
		private readonly IRepositoryManager _manager;

		public ProductController(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var model = _manager.Product.GetAll(false);
			return View(model);
		}

		public IActionResult Get(int id)
		{
			//var model = _Context.Products.FirstOrDefault(p=> p.ProductId.Equals(id));
			throw new NotImplementedException();
		} 
	}
}
