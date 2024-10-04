using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class Categories
    {
        [Key]
        public Guid CategoryID { get; set; }


        public string CategoryName { get; set; }

        public ICollection<Products> Products { get; set; }


    }
}
