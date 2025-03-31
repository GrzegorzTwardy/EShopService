using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Application;
using EShop.Domain.Models;
using EShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class ProductServiceTests
{
    private ProductService _productService;
    private DataContext _context;

    public ProductServiceTests()
    {
        // Tworzymy testową bazę danych w pamięci
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new DataContext(options);
        _context.Database.EnsureCreated();

        var repository = new Repository(_context);
        _productService = new ProductService(repository);

        _context.Products.RemoveRange(_context.Products);
        _context.SaveChanges();
    }

    [Fact]
    public void GetAllProducts_ReturnsEmptyList_WhenNoProductsExist()
    {
        // Act
        var result = _productService.GetAllProducts();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void AddProduct_ShouldAddProductSuccessfully()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Laptop", Price = 2000, Ean = "1", Sku = "111" };

        // Act
        _productService.AddProduct(product);
        var result = _productService.GetAllProducts();

        // Assert
        Assert.Single(result);
        Assert.Equal("Laptop", result.First().Name);
    }

    [Fact]
    public void GetProductById_ShouldReturnCorrectProduct()
    {
        // Arrange
        var product = new Product { Id = 2, Name = "Smartphone", Price = 1000, Ean = "2", Sku = "112" };
        _productService.AddProduct(product);

        // Act
        var result = _productService.GetProductById(2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Smartphone", result.Name);
    }

    [Fact]
    public void DeleteProduct_ShouldRemoveProduct()
    {
        // Arrange
        var product = new Product {Id = 3, Name = "Tablet", Price = 500, Ean = "3", Sku = "113" };
        _productService.AddProduct(product);

        // Act
        _productService.DeleteProduct(3);
        var result = _productService.GetAllProducts();

        // Assert
        Assert.Empty(result);
    }
}
