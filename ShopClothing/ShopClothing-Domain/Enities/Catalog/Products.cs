using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopClothing.Models
{
    public class Products
    {
        [Key]
        public int  ProductID { get; set; }

        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double Price { get; set; }   

        public string ImageProduct { get; set; }

        public DateTime CreatedAt { get; set ;  }

        public DateTime UpdatedAt { get; set; }
      

        // Foreign Key  
        
        public int CategoryID { get; set; }

        // Navigation Property


        [JsonIgnore]
        public Categories Category { get; set; }

        public ICollection<ColorSizes> ColorSizes { get; set; }

        [JsonIgnore]
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        [JsonIgnore]
        public ICollection<Cart_item> CartItems { get; set; } = new List<Cart_item>();

    }
}
