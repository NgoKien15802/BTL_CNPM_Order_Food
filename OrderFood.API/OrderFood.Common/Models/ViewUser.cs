using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class ViewUser
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int? Gender { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public Guid RoleId { get; set; }
    }
}
