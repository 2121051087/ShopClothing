using ShopClothing.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace ShopClothing.Models
{
    public class Colors
    {
        [Key]
        public int ColorID { get; set; }

        public string ColorName { get; set; }

    

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
                       
                        ColorName = colorName,
                       
                    });
                }

                context.Colors.AddRange(defaultColors);
                context.SaveChanges();
            }
        }
    }
}