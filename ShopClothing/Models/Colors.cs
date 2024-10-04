using ShopClothing.Data;
using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class Colors
    {
        [Key]
        public Guid ColorID { get; set; }

        public string ColorName { get; set; }

        public string? ImageColor { get; set; }

        public ICollection<ColorSizes> ColorSizes { get; set; }

        public static void SeedDefaultColors(ShopClothingContext context)
        {
            if (!context.Colors.Any())
            {
                var colorNames = new string[] { "Red", "Blue", "White", "Black", "Yellow", "Green", "Purple", "Pink", "Orange", "Brown", "Gray", "Silver", "Gold" };

                var defaultColors = new List<Colors>();
                foreach (var colorName in colorNames)
                {
                    defaultColors.Add(new Colors
                    {
                        ColorID = Guid.NewGuid(),
                        ColorName = colorName,
                        ImageColor = null
                    });
                }

                context.Colors.AddRange(defaultColors);
                context.SaveChanges();
            }
        }
    }
}