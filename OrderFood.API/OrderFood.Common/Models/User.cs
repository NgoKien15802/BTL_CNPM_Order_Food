using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class User
    {
        public User()
        {
            Bills = new HashSet<Bill>();
            Orders = new HashSet<Order>();
        }

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

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
