using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
	public interface IProductService
	{
		IEnumerable<Product> GetAllProducts(bool trackChanges);
		Product? GetOneProduct(int id, bool trackChanges);
		void CreateProduct(Product product);//burdanda productmanager kısmında implemente ediyoruz 
		void UpdateOneProduct(Product product);//id yi ayrı bir parametre olarak alabiliriz fakat formun içinden geldiği için gerek kalmıyor
		void DeleteOneProduct(int id);
	}
}
