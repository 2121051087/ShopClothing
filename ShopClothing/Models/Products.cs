using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class Products
    {
        [Key]
        public Guid ProductID { get; set; }


        public string ProductName { get; set; }


        public string? ProductDescription { get; set; }

        public double Price { get; set; }   

        public string ImageProduct { get; set; }

        public DateTime CreatedAt { get; set ;  }

        public DateTime UpdatedAt { get; set; }
        public int Quantity { get; set; }

        // Foreign Key
        public Guid CategoryID { get; set; }

        // Navigation Property
        public Categories Category { get; set; }
    }
}
