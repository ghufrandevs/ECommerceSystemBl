using System.ComponentModel.DataAnnotations;

namespace ECommerceSystemBl.DTOs.Category
{
    public class CategoryCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}