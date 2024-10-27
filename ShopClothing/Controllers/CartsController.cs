using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Data;
using ShopClothing.Helpers;
using ShopClothing.Models;
using ShopClothing.Repositories;

namespace ShopClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _repo;

        public CartsController(ICartRepository repo)
        {
            _repo = repo;
        }


        [HttpPost("add-item-to-cart")]
        [Authorize(Roles =AppRole.Customer)]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDTO model )
        {
            try
            {
                await _repo.AddItemToCartAsync(model);
                return Ok("Sản phẩm đã được thêm vào giỏ hàng.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("remove-item-to-cart")]
        [Authorize(Roles = AppRole.Customer)]
        public async Task<IActionResult> RemoveItemToCart(int cartItemId)
        {
            try
            {
                await _repo.RemoveItemFromCartAsync(cartItemId);
                return Ok("Sản phẩm đã được xóa khỏi giỏ hàng");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{cartItemId}")]
        [Authorize(Roles = AppRole.Customer)]
        public async Task<IActionResult> UpdateCartItemInCartAsync(int cartItemId, [FromBody] Dictionary<string, object> updates)
        {
            var result = await _repo.UpdateCartItemAsync(cartItemId, updates);

            if (result)
            {
                return Ok(new { Message = "Cart item updated successfully" });
            }
            return NotFound(new { Message = "Cart item not found" });
        }




    }
}
