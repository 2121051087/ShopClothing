using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class Colors
    {
        [Key]
        public Guid ColorID { get; set; }

        public string ColorName { get; set; }

        public string ImageColor { get; set; }

        public ICollection<ColorSizes> ColorSizes { get; set; }
    }
}
