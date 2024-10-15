using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopClothing.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        [JsonIgnore]
        public ICollection<Products> Products { get; set; } = new List<Products>();


    }
}
