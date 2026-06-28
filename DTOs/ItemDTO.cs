using System.ComponentModel.DataAnnotations;

namespace ECommerceSystemBl.DTOs
{
    public class ItemDTO
    {
       
        
            [Required]
            public int ProductId { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public int Quantity { get; set; }
        }
}
