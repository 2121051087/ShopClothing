using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Models;
using ShopClothing.Repositories;

namespace ShopClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;

        public AccountsController(IAccountRepository repo)
        {
            _accountRepo = repo;
        }
        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var result = await _accountRepo.SignUpAsync(model);
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

            var result = await _accountRepo.SignInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return StatusCode(500);
            }
            return Ok(result);



        }
    }
}
