using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class Sizes
    {
        [Key]
        public Guid SizeID { get; set; }

        public string SizeName { get; set; }    

        public int quantity { get; set; }

        public ICollection<ColorSizes> ColorSizes { get; set; }
    }
}
