using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressoLearningApi.Data;
using ExpressoLearningApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpressoLearningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ExpressoDbContext _expressoDbContext;

        public ProductsController(ExpressoDbContext expressoDbContext)
        {
            _expressoDbContext = expressoDbContext;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult Get()
        {
           var products = (from p in _expressoDbContext.Products
                            join c in _expressoDbContext.Categories
                            on p.CategoryId equals c.CategoryId
                            select new
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                ProductDescription = p.ProductDescription,
                                ProductPrice = p.ProductPrice,
                                ProductImage = p.ProductImage,
                                CategoryId = c.CategoryId,
                                CategoryName = c.CategoryName
                            });
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetProduct(int id)
        {
            var product = (from p in _expressoDbContext.Products
                            join c in _expressoDbContext.Categories
                            on p.CategoryId equals c.CategoryId
                            where p.ProductId == id
                            select new
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                ProductDescription = p.ProductDescription,
                                ProductPrice = p.ProductPrice,
                                ProductImage = p.ProductImage,
                                CategoryId = c.CategoryId,
                                CategoryName = c.CategoryName,
                                CategoryImage = c.CategoryImage
                            });
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Post([FromBody] ProductViewModel productViewModel)
        {
            Product product = new Product
            {
                ProductName = productViewModel.ProductName,
                ProductDescription = productViewModel.ProductDescription,
                ProductPrice = productViewModel.ProductPrice,
                ProductImage = productViewModel.ProductImage,
                CategoryId = productViewModel.CategoryId
            };
            _expressoDbContext.Products.Add(product);
            _expressoDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }


        // PUT: api/products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductViewModel productViewModel)
        {
            var product = _expressoDbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                product.ProductName = productViewModel.ProductName;
                product.ProductDescription = productViewModel.ProductDescription;
                product.ProductPrice = productViewModel.ProductPrice;
                product.ProductImage = productViewModel.ProductImage;
                product.CategoryId = productViewModel.CategoryId;
                _expressoDbContext.SaveChanges();
                return Ok(product);
            }
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _expressoDbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _expressoDbContext.Products.Remove(product);
                _expressoDbContext.SaveChanges();
                return Ok();
            }
        }
    }
}
