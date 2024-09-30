using Microsoft.AspNetCore.Identity;

namespace ShopClothing.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;


    }
}
