using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Entities.Models;
namespace Repositories
{
	public class RepositoryContext : DbContext //veitabanı gibi işlem görür.
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

		public RepositoryContext(DbContextOptions<RepositoryContext> options)
			: base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>()
				.HasData(
				new Product() { ProductId = 1, ProductName = "Bilgisayar", Price = 17_000 },
				new Product() { ProductId = 2, ProductName = "Klavye", Price = 1_000 },
				new Product() { ProductId = 3, ProductName = "Mouse", Price = 500 },
				new Product() { ProductId = 4, ProductName = "Monitor", Price = 4_000 },
				new Product() { ProductId = 5, ProductName = "Kasa", Price = 15_000 },
				new Product() { ProductId = 6, ProductName = "SSD", Price = 2_000 }
				);
			modelBuilder.Entity<Category>()
				.HasData(
				new Category() { CategoryId = 1, CategoryName = "Kitaplar" },
				new Category() { CategoryId = 2, CategoryName = "Elektronik" }
				);
		}

	}
}
