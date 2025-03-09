using Microsoft.AspNetCore.Mvc;
using EShopService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EShopService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_products.Where(p => !p.Deleted));
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id && !p.Deleted);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product)
        {
            product.Id = _nextId++;
            product.CreatedAt = DateTime.UtcNow;
            product.CreatedBy = Guid.NewGuid();
            _products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Update(int id, [FromBody] Product updated)
        {
            var product = _products.FirstOrDefault(p => p.Id == id && !p.Deleted);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Ean = updated.Ean;
            product.Price = updated.Price;
            product.Stock = updated.Stock;
            product.Sku = updated.Sku;
            product.Category = updated.Category;
            product.UpdatedAt = DateTime.UtcNow;
            product.UpdatedBy = Guid.NewGuid();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id && !p.Deleted);
            if (product == null) return NotFound();

            product.Deleted = true;
            product.UpdatedAt = DateTime.UtcNow;
            product.UpdatedBy = Guid.NewGuid();
            return NoContent();
        }
    }
}
