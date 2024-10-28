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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repo;

        public OrdersController(IOrderRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("create-order")]
        [Authorize(Roles = AppRole.Customer)]
        public async Task<IActionResult> CreateOrder([FromBody] OrdersDTO model)
        {
            try
            {
                await _repo.CreateOrderAsync(model); 
                return Ok("Đơn hàng đã được tạo thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //[HttpGet("get-orders-by-user")]
        //[Authorize(Roles = AppRole.Customer)]
        //public async Task<IActionResult> GetOrdersByUser()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    var orders = await _repo.GetOrdersByUserIdAsync(userId);
        //    return Ok(orders);
        //}

        //[HttpGet("get-order-by-id")]
    }
}
