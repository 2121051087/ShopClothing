using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Data;
using ShopClothing.Models;
using ShopClothing.Repositories;

namespace ShopClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoriesController(ICategoryRepository repo)
        {
            _categoryRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {

           var result = await _categoryRepo.GetAllCategories();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Categories category)
        {
            try
            {
                var result = await _categoryRepo.AddNewCategory(category);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Categories category ,string id)
        {
            try
            {
                var result = await _categoryRepo.UpdateCategory(category,id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory( string id)
        {
            try
            {
                var result = await _categoryRepo.DeleteCategory(id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
