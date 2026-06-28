using System.ComponentModel.DataAnnotations;

namespace ECommerceSystemBl.DTOs
{
    public class LoginDTO
    {
        
            [Required]
            [EmailAddress]
            public string UserEmail { get; set; }

            [Required]
            public string UserPassword { get; set; }
        }
    }

