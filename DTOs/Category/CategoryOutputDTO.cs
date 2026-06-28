namespace ECommerceSystemBl.DTOs.Category
{
    public class CategoryOutputDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}