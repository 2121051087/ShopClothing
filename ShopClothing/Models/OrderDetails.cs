using System.Text.Json.Serialization;

namespace ShopClothing.Models
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public Guid ColorSizesID { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Navigation Property  
        [JsonIgnore]
        public Products Products { get; set; }

        public ColorSizes ColorSizes { get; set; }

        public Orders Orders { get; set; }
    }
}
