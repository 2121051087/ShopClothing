using ShopClothing.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopClothing.Models
{
    public class Sizes
    {
        [Key]
        
        public int SizeID { get; set; }

        public string SizeName { get; set; }    

      
        public ICollection<ColorSizes> ColorSizes { get; set; }

        public static void SeedDefaultSizes(ShopClothingContext context)
        {
            if (!context.Sizes.Any())
            {
                var sizeNames = new string[] { "X", "M", "XL", "L", "S" };

                var defaultSizes = new List<Sizes>();

                foreach (var size in sizeNames)
                {
                    defaultSizes.Add(new Sizes
                    {

                        SizeName = size,

                    });
                }

                context.Sizes.AddRange(defaultSizes);
                context.SaveChanges();
            }
        }

    }
}
