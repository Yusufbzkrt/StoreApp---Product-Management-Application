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
builder.Services.AddRazorPages();//controller olmadanda razor page leri kullanabilmemizi saðlayan servis. kullanmak için en aþaðý enpointte eklemeliyiz.

builder.Services.AddDbContext<RepositoryContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("StoreApp"));
});

//oturum yönetimi ve önbellekleme iþlemleri için gerekli yapýlandýrmalar
builder.Services.AddDistributedMemoryCache();//sýkça eriþilen verilerin bellekte tutulmasýna olanak tanýr
builder.Services.AddSession(Options =>
{
	Options.Cookie.Name = "StoreApp.Session";//oturum bilgilerini saklamak için kullanýlan çerezin adýný belirler.
	Options.IdleTimeout = TimeSpan.FromMinutes(10);//oturumu 10 dk açýk tut
}); //Bu sayede, kullanýcý sayfalar arasýnda geçiþ yapsa bile bu bilgiler korunur. 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//alttaki 3 ifade repo için kayýtlý
builder.Services.AddScoped<IRepositoryManager, RepositoryManger>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//alttaki 3 ifade Service için kayýtlý
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();


//AddScoped her kullanýcýya özel sepet oluþturmaya yarýyor.
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
app.UseSession();//sessionlarý açýk hale getiriyoruz

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
