using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Entities.Models;
using Repositories.Config;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Repositories
{
	public class RepositoryContext : IdentityDbContext<IdentityUser> //veitabanı gibi işlem görür.
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }

		public RepositoryContext(DbContextOptions<RepositoryContext> options)
			: base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			/*
			modelBuilder.ApplyConfiguration(new ProductConfig());//config dosyalarımızı tanımladık
			modelBuilder.ApplyConfiguration(new CategoryConfig());
		*/        /*        VEYA          */

			//bu kod bloğu daha kullanışlıdır her yeni eklenen nesne için buraya yazmamıza gerek kalmaz kendisi otomatik olarak ekler.
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			}

	}
}
