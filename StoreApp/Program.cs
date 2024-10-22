using StoreApp.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();//controller olmadanda razor page leri kullanabilmemizi saðlayan servis. kullanmak için en aþaðý enpointte eklemeliyiz.

builder.Services.ConfigureDbContext(builder.Configuration);//ServiceExtensiondaki metoda baðlandý
builder.Services.ConfigureIdentity();

//oturum yönetimi ve önbellekleme iþlemleri için gerekli yapýlandýrmalar
builder.Services.ConfigureSession();

//alttaki ifade repo için kayýtlý
builder.Services.ConfigureRepositoryRegistration();

//alttaki ifade Service için kayýtlý
builder.Services.ConfigureServiceRegistration();

builder.Services.AddAutoMapper(typeof(Program));

//routelarýn küçük harfle baþlamasý
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
app.UseSession();//sessionlarý açýk hale getiriyoruz
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints?.ConfigureCustomRoutes();
});

app.ConfigureAndCheckMigration();//Auto Migrate sadece update yapmayý ortadan kaldýrýr
app.ConfigureLocalization();//türk lirasý uygulama - yerelleþtirme
app.ConfigureDefaultAdminUser();
app.Run();
