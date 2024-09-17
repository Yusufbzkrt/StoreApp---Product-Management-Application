using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(
				new Product() { ProductId = 1, CategoryId = 2, ProductName = "Bilgisayar", Price = 17_000 },
				new Product() { ProductId = 2, CategoryId = 2, ProductName = "Klavye", Price = 1_000 },
				new Product() { ProductId = 3, CategoryId = 2, ProductName = "Mouse", Price = 500 },
				new Product() { ProductId = 4, CategoryId = 2, ProductName = "Monitor", Price = 4_000 },
				new Product() { ProductId = 5, CategoryId = 2, ProductName = "Kasa", Price = 15_000 },
				new Product() { ProductId = 6, CategoryId = 1, ProductName = "Piraye", Price = 2_000 },
				new Product() { ProductId = 7, CategoryId = 1, ProductName = "Hamlet", Price = 2_000 }
				);
		}
	}
}
