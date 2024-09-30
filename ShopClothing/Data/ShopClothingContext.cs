using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShopClothing.Data
{
    public class ShopClothingContext : IdentityDbContext<ApplicationUser>
    {
        public ShopClothingContext(DbContextOptions<ShopClothingContext> options) : base(options)
        {
        }
    }
}
