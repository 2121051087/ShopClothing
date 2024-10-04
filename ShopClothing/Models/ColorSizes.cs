using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class ColorSizes
    {
        [Key]
        public Guid ColorSizesID { get; set; }

        public int Quantity { get; set; }   

        // Foreign Key
        public Guid ColorID { get; set; }

        public Guid SizeID { get; set; }

        public Guid ProductID { get; set; }

        // Navigation Property

        public Products Product { get; set; }
        public Sizes sizes { get; set; }
        public Colors Color { get; set; }

      

    }
}
