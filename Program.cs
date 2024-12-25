using KuaforProjesi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DataContext
builder.Services.AddDbContext<DataContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("database");
    options.UseSqlite(connectionString);
});

// Configure IdentityContext
builder.Services.AddDbContext<IdentityContext>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:database"]));

// Configure Identity with custom password requirements
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false; // Rakam gereksinimi kapatılır
    options.Password.RequireNonAlphanumeric = false; // Özel karakter gereksinimi kapatılır
    options.Password.RequireUppercase = false; // Büyük harf gereksinimi kapatılır
    options.Password.RequiredLength = 3; // Minimum uzunluk 3 olarak ayarlanır
})
.AddEntityFrameworkStores<IdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Identity için Authentication Middleware'i ekle
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await IdentitySeedData.IdentityTestUser(app); // Seed admin user

app.Run();
