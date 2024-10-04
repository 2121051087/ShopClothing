using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }


        public string CategoryName { get; set; }

        public ICollection<Products> Products { get; set; }


    }
}
