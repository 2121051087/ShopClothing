using ShopClothing.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopClothing.Models
{
    public class Carts
    {
        [Key]
        public int CartID { get; set; }

        public string UserID { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Navigation Property

      
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Cart_item> cart_Items { get; set; } = new List<Cart_item>();
    }
}
