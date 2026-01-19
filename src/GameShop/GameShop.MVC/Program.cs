using GameShop.DAL.Data;
using GameShop.BLL.Interfaces;
using GameShop.BLL.Services;        
using GameShop.DAL;                
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

//(Connection String)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoreService, StoreService>();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();

        DbSeeder.Seed(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Greška pri seedovanju baze: " + ex.Message);
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();