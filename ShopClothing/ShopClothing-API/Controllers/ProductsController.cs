﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Data;
using ShopClothing.Infrastructure.Repositories;
using ShopClothing.Models;


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

                await _repo.AddNewProductAsync(product, base64Image);
                return Ok(product);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            if(id != null)
            {
                await _repo.DeleteProductAsync(id);

                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProductAsync(string? search, double? from, double? to ,string? SortBy, string? categoryName, int page)
        {
            var products = await _repo.GetAllProductAsync(search ,from ,to,SortBy, categoryName, page);
            return Ok(products);
        }
    }
}
