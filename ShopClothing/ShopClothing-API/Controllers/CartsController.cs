using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Data;
using ShopClothing.Infrastructure.Helpers;
using ShopClothing.Infrastructure.Unit;
using ShopClothing.Models;

using System.Security.Claims;

namespace ShopClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CartsController( IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpPost("add-item-to-cart")]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Customer}")]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDTO model )
        {
            try
            {
                await unitOfWork.CartRepository.AddItemToCartAsync(model);
                return Ok("Sản phẩm đã được thêm vào giỏ hàng.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("remove-item-to-cart")]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Customer}")]
        public async Task<IActionResult> RemoveItemToCart(int cartItemId)
        {
            try
            {
                await unitOfWork.CartRepository.RemoveItemFromCartAsync(cartItemId);
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
            var result = await unitOfWork.CartRepository.UpdateCartItemAsync(cartItemId, updates);

            if (result)
            {
                return Ok(new { Message = "Cart item updated successfully" });
            }
            return NotFound(new { Message = "Cart item not found" });
        }
        [HttpGet]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Customer}")]
        public Task<Carts> GetOrCreateCartAsync()
        {
            var userId = unitOfWork.AccountRepository.GetUserId();
            return unitOfWork.CartRepository.GetOrCreateCartAsync(userId);
        }


    }
}
