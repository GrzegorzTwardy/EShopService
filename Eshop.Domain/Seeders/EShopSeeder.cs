using EShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.Repositories;
namespace EShop.Domain.Seeders;

public class EShopSeeder(DataContext context) : IEShopSeeder
{
    public async Task Seed()
    {
        // Sprawdzenie czy tabela jest pusta
        if (!context.Products.Any())
        {
            var products = new List<Product>
        {
            new Product { Name = "Dan" },
            new Product { Name = "Diogo"},
            new Product { Name = "Dorota" }
        };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}

