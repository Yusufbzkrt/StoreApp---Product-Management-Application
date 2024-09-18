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
				new Product() { ProductId = 1, CategoryId = 2, ImageUrl = "/img/1.jpg", ProductName = "Bilgisayar", Price = 17_000 },
				new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/img/2.jpg", ProductName = "Klavye", Price = 1_000 },
				new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/img/3.jpg", ProductName = "Mouse", Price = 500 },
				new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "/img/4.jpg", ProductName = "Monitor", Price = 4_000 },
				new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "/img/5.jpg", ProductName = "Kasa", Price = 15_000 },
				new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "/img/6.jpg", ProductName = "Piraye", Price = 2_000 },
				new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "/img/7.jpg", ProductName = "Hamlet", Price = 2_000 }
				);
		}
	}
}
