using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Data;
using ShopClothing.Models;
using ShopClothing.Repositories;


namespace ShopClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]

        public async Task<IActionResult> AddProduct( [FromForm] ProductDetailDTO product)
        {
            //if (product.colorSizesDTO == null || !product.colorSizesDTO.Any())
            //{
            //    return BadRequest("Invalid product data.");
               

            //}
            try
            {
                var result = await _repo.AddNewProductAsync(product);
                return Ok(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, " lỗi tại đây ");
                throw; 
                return StatusCode(500);
            }
        }
    }
}
