using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Contracts;

namespace Services;

public class ProductManager : IProductService
{
	private readonly IRepositoryManager _manager;

	public ProductManager(IRepositoryManager manager)
	{
		_manager = manager;
	}

	public void CreateProduct(Product product)
	{
		_manager.Product.Create(product);
		_manager.Save();//sırada admin/product controllerdan çağırmak kaldı
	}

	public void DeleteOneProduct(int id)
	{
		Product product = GetOneProduct(id,false);
		if (product is not null)
		{
			_manager.Product.DeleteOneProduct(product);
			_manager.Save();
		}

	}

	public IEnumerable<Product> GetAllProducts(bool trackChanges)
	{
		return _manager.Product.GetAllProducts(trackChanges);
	}

	public Product? GetOneProduct(int id, bool trackChanges)
	{
		var product = _manager.Product.GetOneProduct(id, trackChanges);	
		if (product == null)
		{
			throw new Exception("Not Found");
		}
		return product;
	}

	public void UpdateOneProduct(Product product)
	{
		var entity = _manager.Product.GetOneProduct(product.ProductId,true);
		entity.ProductName = product.ProductName;
		entity.Price = product.Price;
		_manager.Save();
	}
}