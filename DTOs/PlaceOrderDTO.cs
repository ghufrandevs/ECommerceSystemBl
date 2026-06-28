using System.ComponentModel.DataAnnotations;

namespace ECommerceSystemBl.DTOs
{
    public class PlaceOrderDTO
    {
            

        [Required]
        [MinLength(1)]
        public List<ItemDTO> Items { get; set; }
        }
}
