using Microsoft.AspNetCore.Identity;
using ShopClothing.Models;
using System.Reflection.Metadata;

namespace ShopClothing.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
