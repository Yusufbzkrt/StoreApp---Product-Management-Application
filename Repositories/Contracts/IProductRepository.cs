using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
	public interface IProductRepository : IRepositoryBase<Product>
	{
		IQueryable<Product> GetAllProducts(bool trackChanges);
		IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
		IQueryable<Product> GetShowcaseProduct(bool trackChanges);
		Product? GetOneProduct(int id, bool trackChanges);
		void CreateOneProduct(Product product);//önce base üzerinden bir tanımlama yaptık şimdi ise IProductrepository üzerinde
											   //daha sonra bunu ProductRepository kısmında implemente ettik
											   //daha sonra ordan da services kısmına geçip Iproductservicede createnin tanımlamsını yaptık.

		void DeleteOneProduct(Product product);
		void UpdateOneProduct(Product entity);
	}
}
