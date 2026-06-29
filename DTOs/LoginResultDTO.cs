namespace ECommerceSystemBl.DTOs
{
    public class LoginResultDTO
    {
        public string Message { get; set; } = "";

        public string Token { get; set; } = "";

        public int UserId { get; set; }

        public string UserName { get; set; } = "";

        public string Role { get; set; } = "";
    }
}