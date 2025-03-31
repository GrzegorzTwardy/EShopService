using EShop.Domain.Models;
using EShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application;

public class ProductService
{
    private readonly Repository _productRepository;

    public ProductService(Repository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAll();
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetById(id);
    }

    public void AddProduct(Product product)
    {
        _productRepository.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.Update(product);
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(id);
    }
}
