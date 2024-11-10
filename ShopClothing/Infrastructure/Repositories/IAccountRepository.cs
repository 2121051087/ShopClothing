using Microsoft.AspNetCore.Identity;
using ShopClothing.Models;

namespace ShopClothing.Infrastructure.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);

        public Task<string> SignInAsync(SignInModel model);

        public string GetUserId();
    }
}
