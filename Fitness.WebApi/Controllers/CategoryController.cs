using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Core.Repositories.Categories;
using Fitness.Core.Repositories.Categories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryRepository<CategoryModel> _category { get; set; }
        public CategoryController(ICategoryRepository<CategoryModel> category)
        {
            _category = category;
        }


        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var categories = await _category.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _category.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            await _category.Create(category);
            return Created("Category/Create", category);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CategoryModel category)
        {
            await _category.Update(category);
            var categoryResult = await _category.GetByIdAsync(category.Id);
            return Ok(categoryResult);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _category.Delete(id);
            var categories = _category.GetAllAsync();
            return Ok(categories);
        }
    }
}