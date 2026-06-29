namespace ECommerceSystemBl.DTOs
{
    public class ReviewOutputDTO
    {
        public int ReviewId { get; set; }

        public string UserName { get; set; } = "";

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}