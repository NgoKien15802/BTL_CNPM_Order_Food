using OrderFood.Common.Enums;

namespace OrderFood.Common.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }

        public string FullName { get; set; } = "";

        public string Username { get; set; } = "";

        public string Email { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string? Address { get; set; }

        public string? Avatar { get; set; }

        public Gender? Gender { get; set; }

        public string? Token { get; set; }
    }
}
