using Microsoft.AspNetCore.Identity;
using ShopClothing.Models;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace ShopClothing.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        //public int CartID { get; set; } // This is a foreign key


        //public ICollection<Carts> Cart { get; set; } = new List<Carts>();
        
        public ICollection<Carts> carts { get; set; } = new List<Carts>();

        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
