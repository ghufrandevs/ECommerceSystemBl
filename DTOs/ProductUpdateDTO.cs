using System.ComponentModel.DataAnnotations;

namespace ECommerceSystemBl.DTOs
{
    public class ProductUpdateDTO
    {
        [Required]
        public string ProductName { get; set; }

        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
