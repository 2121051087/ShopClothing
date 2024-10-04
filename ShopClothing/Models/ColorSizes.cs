using System.ComponentModel.DataAnnotations;

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

        public Products Product { get; set; }
        public Sizes sizes { get; set; }
        public Colors Color { get; set; }

      

    }
}
