using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "UserScheme";             // Scheme mặc định nếu không chỉ định
    options.DefaultChallengeScheme = "UserScheme";    // Khi gặp [Authorize] mà chưa đăng nhập
})
.AddCookie("UserScheme", options =>
{
    options.LoginPath = "/Home/Login";
    options.AccessDeniedPath = "/Home/Login";
    options.Cookie.Name = "UserCookie";
})
.AddCookie("AdminScheme", options =>
{
    options.LoginPath = "/Admin/Home/Login";
    options.AccessDeniedPath = "/Admin/Login";
    options.Cookie.Name = "AdminCookie";
});
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowOrigin", p =>
    {
        p.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. System.InvalidOperationException: 'The service collection cannot be modified because it is read-only.'You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();


