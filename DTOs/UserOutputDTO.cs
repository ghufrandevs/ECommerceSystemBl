namespace ECommerceSystemBl.DTOs
{
    public class UserOutputDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPhone { get; set; }

        public string Role { get; set; } = "";

        public bool IsActive { get; set; }
    }
}
