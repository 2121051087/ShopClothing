using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Models
{
    public class SignUpModel
    {
        [Required]
        public string FirstName { get; set; } = null!;


        [Required]
        public string LastName { get; set; } = null!;


        [Required, EmailAddress]
        public string Email { get; set; } = null!;


        [Required, MinLength(6)]
        public string Password { get; set; } = null!;


        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
