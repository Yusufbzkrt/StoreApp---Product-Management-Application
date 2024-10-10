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
				new Product() { ProductId = 1, CategoryId = 2, ImageUrl = "/img/2.jpg", ProductName = "Bilgisayar", Price = 17_000, ShowCase = false },
				new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/img/5.jpg", ProductName = "Klavye", Price = 1_000, ShowCase = false },
				new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/img/1.jpg", ProductName = "Mouse", Price = 500, ShowCase = false },
				new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "/img/3.jpg", ProductName = "Kamera", Price = 4_000, ShowCase = false },
				new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "/img/6.jpg", ProductName = "Kasa", Price = 15_000, ShowCase = false },
				new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "/img/4.jpg", ProductName = "Piraye", Price = 2_000, ShowCase = false },
				new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "/img/7.jpg", ProductName = "Hamlet", Price = 2_000, ShowCase = false },
				new Product() { ProductId = 8, CategoryId = 2, ImageUrl = "/img/8.jpg", ProductName = "Xp-Pen", Price = 4_000,ShowCase=true },
				new Product() { ProductId = 9, CategoryId = 2, ImageUrl = "/img/9.jpg", ProductName = "Samsung Galaxy FE", Price = 8_000,ShowCase = true },
				new Product() { ProductId = 10, CategoryId = 2, ImageUrl = "/img/10.jpg", ProductName = "Hp Mouse", Price = 5000, ShowCase = true }
				);
		}
	}
}
