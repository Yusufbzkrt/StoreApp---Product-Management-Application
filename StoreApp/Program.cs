using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();//controller olmadanda razor page leri kullanabilmemizi sa�layan servis. kullanmak i�in en a�a�� enpointte eklemeliyiz.

builder.Services.AddDbContext<RepositoryContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("StoreApp"));
});

//oturum y�netimi ve �nbellekleme i�lemleri i�in gerekli yap�land�rmalar
builder.Services.AddDistributedMemoryCache();//s�k�a eri�ilen verilerin bellekte tutulmas�na olanak tan�r
builder.Services.AddSession(Options =>
{
	Options.Cookie.Name = "StoreApp.Session";//oturum bilgilerini saklamak i�in kullan�lan �erezin ad�n� belirler.
	Options.IdleTimeout = TimeSpan.FromMinutes(10);//oturumu 10 dk a��k tut
}); //Bu sayede, kullan�c� sayfalar aras�nda ge�i� yapsa bile bu bilgiler korunur. 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//alttaki 3 ifade repo i�in kay�tl�
builder.Services.AddScoped<IRepositoryManager, RepositoryManger>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//alttaki 3 ifade Service i�in kay�tl�
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();


//AddScoped her kullan�c�ya �zel sepet olu�turmaya yar�yor.
builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();//sessionlar� a��k hale getiriyoruz

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
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
});


app.Run();
