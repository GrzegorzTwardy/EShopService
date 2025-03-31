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
        if (!context.Products.Any())
        {
            var products = new List<Product>
        {
            new Product { Name = "p1" },
            new Product { Name = "p2"},
            new Product { Name = "p3" }
        };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}

