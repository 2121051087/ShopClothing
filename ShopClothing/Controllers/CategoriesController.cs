using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Data;
using ShopClothing.Helpers;
using ShopClothing.Infrastructure;
using ShopClothing.Models;
using ShopClothing.Repositories;

namespace ShopClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
    
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Customer}")]
        public async Task<IActionResult> GetAllCategory()
        {

           var result = await _unitOfWork.CategoryRepository.GetAllCategories();

            await _unitOfWork.SaveChangesAsync();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> AddCategory(Categories category)
        {
            try
            {
                var result = await _unitOfWork.CategoryRepository.AddNewCategory(category);

                await _unitOfWork.SaveChangesAsync();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> UpdateCategory(Categories category ,string id)
        {
            
            try
            {
                if (id != category.CategoryID.ToString())
                {
                  var error =  "id sai hoặc category ko tồn tại";
                    return BadRequest(error);
                }
                var result = await _unitOfWork.CategoryRepository.UpdateCategory(category,id);

                await _unitOfWork.SaveChangesAsync();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _unitOfWork.CategoryRepository.DeleteCategory(id);

                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        
        }

    }
}
