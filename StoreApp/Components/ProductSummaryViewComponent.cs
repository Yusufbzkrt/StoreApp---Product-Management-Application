using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Components
{//kaç ürün varsa sayısını dönsün
	public class ProductSummaryViewComponent : ViewComponent
	{
		private readonly IServiceManager _manager;

		public ProductSummaryViewComponent(IServiceManager manager)
		{
			_manager = manager;
		}

		public string Invoke()
		{
			return _manager.ProductService.GetAllProducts(false).Count().ToString();
		}
	}
}