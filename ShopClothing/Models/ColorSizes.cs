using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopClothing.Models
{
    public class ColorSizes
    {
        [Key]
        public Guid ColorSizesID { get; set; }

        public int Quantity { get; set; }   

        // Foreign Key
        public int ColorID { get; set; }

        public int SizeID { get; set; }

        public int ProductID { get; set; }

        // Navigation Property

        [JsonIgnore]
        public Products Product { get; set; }
        [JsonIgnore]
        public Sizes sizes { get; set; }
        [JsonIgnore]
        public Colors Color { get; set; }

      

    }
}
