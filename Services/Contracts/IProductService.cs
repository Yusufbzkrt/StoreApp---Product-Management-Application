using Entities.Dtos;
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
		void CreateProduct(ProductDtoForInsertion productDto);//burdanda productmanager kısmında implemente ediyoruz 
		void UpdateOneProduct(ProductDtoForUpdate product);//id yi ayrı bir parametre olarak alabiliriz fakat formun içinden geldiği için gerek kalmıyor
		void DeleteOneProduct(int id);
		ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
	}
}