using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Infrastructure.Repositories;
using ShopClothing.Infrastructure.Unit;
using ShopClothing.Models;

namespace ShopClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
      
        private readonly IUnitOfWork unitOfWork;

        public AccountsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var result = await unitOfWork.AccountRepository.SignUpAsync(model);
                return result.Succeeded ? Ok(result) : BadRequest(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {

            var result = await unitOfWork.AccountRepository.SignInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return StatusCode(500);
            }
            return Ok(result);


        }
    }
}
