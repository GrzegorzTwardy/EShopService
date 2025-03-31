using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using EShop.Application;
using EShop.Domain.Repositories;
using EShop.Domain.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Dodanie serwisów do kontenera DI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Rejestracja DbContext (In-Memory Database)
builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("TestDatabase"));

// Rejestracja serwisów i repozytoriów
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<Repository>();

// Rejestracja Seedera (jeœli istnieje)
builder.Services.AddScoped<IEShopSeeder, EShopSeeder>(); // Upewnij siê, ¿e EShopSeeder implementuje IEShopSeeder

var app = builder.Build();

// Tworzenie skryptu seeduj¹cego bazê danych
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IEShopSeeder>();
    await seeder.Seed();
}

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
