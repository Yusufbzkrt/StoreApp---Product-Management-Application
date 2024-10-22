using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Services;
using Entities.Models;
using StoreApp.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Extensions
{
	public static class ServiceExtension
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<RepositoryContext>(options =>
			{
				options.UseSqlite(configuration.GetConnectionString("sqlConnection"),
					b => b.MigrationsAssembly("StoreApp"));

				options.EnableSensitiveDataLogging(true);
			});
		}

		public static void ConfigureIdentity(this IServiceCollection services)
		{
			services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.User.RequireUniqueEmail = true;
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 8;
			})
				.AddEntityFrameworkStores<RepositoryContext>();//Bu kısım, ASP.NET Core Identity verilerini (kullanıcı ve roller) Entity Framework ile RepositoryContext veritabanına kaydeder. 
		}

		public static void ConfigureSession(this IServiceCollection services)
		{
			services.AddDistributedMemoryCache();//sıkça erişilen verilerin bellekte tutulmasına olanak tanır
			services.AddSession(Options =>
			{
				Options.Cookie.Name = "StoreApp.Session";//oturum bilgilerini saklamak için kullanılan çerezin adını belirler.
				Options.IdleTimeout = TimeSpan.FromMinutes(10);//oturumu 10 dk açık tut
			}); //Bu sayede, kullanıcı sayfalar arasında geçiş yapsa bile bu bilgiler korunur. 
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			//AddScoped her kullanıcıya özel sepet oluşturmaya yarıyor.
			services.AddScoped<Cart>(c => SessionCart.GetCart(c));

		}
		public static void ConfigureRepositoryRegistration(this IServiceCollection services)
		{
			//alttaki  ifadeler repo için kayıtlı
			services.AddScoped<IRepositoryManager, RepositoryManger>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
		}

		public static void ConfigureServiceRegistration(this IServiceCollection services)
		{
			//alttaki ifadeler Service için kayıtlı
			services.AddScoped<IServiceManager, ServiceManager>();
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<IOrderService, OrderManager>();
			services.AddScoped<IAuthService, AuthManager>();
		}

		public static void ConfigureCustomRoutes(this IEndpointRouteBuilder endpoints)
		{
			// Admin Area Routing
			endpoints.MapAreaControllerRoute(
				name: "Admin",
				areaName: "Admin",
				pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

			// Default Route
			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			endpoints.MapRazorPages();

			endpoints.MapControllers();
		}
		public static void ConfigureRouting(this IServiceCollection services)
		{
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true;
				options.AppendTrailingSlash = false;//sona slash ifadesi eklensin mi?
			});
		}

	}
}
