using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressoLearningApi.Data;
using ExpressoLearningApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpressoLearningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ExpressoDbContext _expressoDbContext;

        public CategoriesController(ExpressoDbContext expressoDbContext)
        {
            _expressoDbContext = expressoDbContext;
        }

        // GET api/categories
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _expressoDbContext.Categories.Include("Products");
            return Ok(categories);
        }

        // GET api/categories/2
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _expressoDbContext.Categories.Include("Products").FirstOrDefault(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/categories
        [HttpPost]
        public IActionResult Post([FromBody] CategoryViewModel categoryViewModel)
        {
            Category category = new Category
            {
                CategoryName = categoryViewModel.CategoryName,
                CategoryImage = categoryViewModel.CategoryImage
            };
            _expressoDbContext.Categories.Add(category);
            _expressoDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryViewModel categoryViewModel)
        {
            var category = _expressoDbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            } else
            {
                category.CategoryName = categoryViewModel.CategoryName;
                category.CategoryImage = categoryViewModel.CategoryImage;
                _expressoDbContext.SaveChanges();
                return Ok(category);
            }
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _expressoDbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                _expressoDbContext.Categories.Remove(category);
                _expressoDbContext.SaveChanges();
                return Ok();
            }
        }
    }
}