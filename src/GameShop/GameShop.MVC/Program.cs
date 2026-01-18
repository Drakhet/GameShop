using GameShop.BLL.Services;        // Koristimo servise iz BLL-a
using GameShop.DAL;                 // Koristimo context iz DAL-a
using GameShop.DAL.Repositories;    // Koristimo repozitorijume iz DAL-a
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// 1. Konekcija na bazu (Connection String)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Povezujemo se na AppDbContext koji je u DAL projektu
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Dependency Injection (Registracija slojeva)
// Svaki put kad neko traži Repozitorijum ili Servis, aplikacija mu daje instancu
builder.Services.AddScoped<GameRepository>();
builder.Services.AddScoped<UserRepository>();

// Ovde registrujemo GameService (koji si već napravio)
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<UserService>();

// builder.Services.AddScoped<UserService>(); // Otkomentariši ovo kad napraviš UserService klasu

// 3. MVC podesavanja
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();