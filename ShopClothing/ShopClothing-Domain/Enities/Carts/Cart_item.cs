using System.Text.Json.Serialization;

namespace ShopClothing.Models
{
    public class Cart_item
    {
        public int Cart_itemID { get; set; }

        public int CartID { get; set; }

        public int ProductID { get; set; }

        public Guid ColorSizesID { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Navigation Property 
    
        public Products Products { get; set; }

        public ColorSizes ColorSizes { get; set; }

        [JsonIgnore]
        public Carts Carts { get; set; }
    }
}
