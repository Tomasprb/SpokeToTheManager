using SpokeToTheManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SpokeToTheManagerDBCF;Trusted_Connection=True;TrustServerCertificate=true"));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option=>{
    option.LoginPath="/acceso/login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=acceso}/{action=login}/{id?}");

app.Run();
