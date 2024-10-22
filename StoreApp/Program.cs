using StoreApp.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();//controller olmadanda razor page leri kullanabilmemizi sa�layan servis. kullanmak i�in en a�a�� enpointte eklemeliyiz.

builder.Services.ConfigureDbContext(builder.Configuration);//ServiceExtensiondaki metoda ba�land�
builder.Services.ConfigureIdentity();

//oturum y�netimi ve �nbellekleme i�lemleri i�in gerekli yap�land�rmalar
builder.Services.ConfigureSession();

//alttaki ifade repo i�in kay�tl�
builder.Services.ConfigureRepositoryRegistration();

//alttaki ifade Service i�in kay�tl�
builder.Services.ConfigureServiceRegistration();

builder.Services.AddAutoMapper(typeof(Program));

//routelar�n k���k harfle ba�lamas�
builder.Services.ConfigureRouting();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints?.ConfigureCustomRoutes();
});

app.ConfigureAndCheckMigration();//Auto Migrate sadece update yapmay� ortadan kald�r�r
app.ConfigureLocalization();//t�rk liras� uygulama - yerelle�tirme
app.ConfigureDefaultAdminUser();
app.Run();
