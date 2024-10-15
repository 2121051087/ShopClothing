using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

       

        [HttpPost]
        public async Task<ActionResult> AddNewCartAsync(Carts cart)
        {
            await _repo.AddCartAsync(cart);
            return Ok(cart);

        }
        

        
    }
}
