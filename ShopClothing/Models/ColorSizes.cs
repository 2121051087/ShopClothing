using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class ColorSizes
    {
        [Key]
        public Guid ColorSizesID { get; set; }

        // Foreign Key
        public Guid ColorID { get; set; }

        public Guid ProductID { get; set; }

        public Guid SizeID { get; set; }


        // Navigation Property
        public Products products { get; set; }

        public Sizes sizes { get; set; }

        public Colors Color { get; set; }
    }
}
