using System.ComponentModel.DataAnnotations;

namespace ECommerceSystemBl.DTOs
{
    public class UserUpdateDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [RegularExpression(
            @"^(?=.*[A-Z])(?=.*\d).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter and one number.")]
        public string? UserPassword { get; set; }

        [Required]
        public string UserPhone { get; set; }

        public string Role { get; set; } = "";

        public bool IsActive { get; set; }
    }
}