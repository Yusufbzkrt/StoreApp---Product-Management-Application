using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
	public static class ProductRepositoryExtensions
	{
		public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products,
			int? categoryId)
		{
			if(categoryId is null)
			{
				return products;
			}
			else
			{
				return products.Where(prd => prd.CategoryId.Equals(categoryId));
			}
		}
		public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products,
			String? searchTerm)
		{
			if(searchTerm is null)
			{
				return products;
			}
			else
			{
				return products.Where(prd=>prd.ProductName.ToLower()//küçük büyük harf ayrımın kaldırdırız
				.Contains(searchTerm.ToLower())
				);
			}
		}

		public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,
			int? minPrice, int? maxPrice,bool IsValidPrice)
		{
			if (IsValidPrice){
				return products.Where(prd => prd.Price>=minPrice && prd.Price<=maxPrice);
			}
            else
            {
				return products;
            }
        }

		public static IQueryable<Product> ToPaginate(this IQueryable<Product> products,
			int pageNumber, int pageSize)
		{

			return products
				.Skip(((pageNumber-1)*pageSize))
				.Take(pageSize);
		}
	}
}
