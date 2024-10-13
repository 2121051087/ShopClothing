using ShopClothing.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public string UserID { get; set; }

        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        public string Status { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Ward { get; set; }

        public string PhoneNumber { get; set; }

        // 

        public ApplicationUser applicationUser { get; set;}

        public ICollection<OrderDetails> orderDetails { get; set; }
    }
}
