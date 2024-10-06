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
        public async Task<IActionResult> AddProduct([FromForm] ProductDetailDTO product, IFormFile ImageProduct)
        {
            string base64Image = null!;
            if (ImageProduct != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ImageProduct.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();
                    base64Image = Convert.ToBase64String(fileBytes);

                }
                List<ColorSidesDTO> colorSizesDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ColorSidesDTO>>(product.colorSizesDTO);

                return Ok(await _repo.AddNewProductAsync(product, base64Image));
            }
            return BadRequest();
        }


    }
}
