using ShopClothing.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Data
{
    public class ProductDetailDTO
    {
        
        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double Price { get; set; }

        
        public IFormFile? formFile { get; set; }
        
        public List<ColorSizes> colorSizes { get; set; }

    }


   
}
