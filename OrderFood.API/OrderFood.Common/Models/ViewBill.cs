using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class ViewBill
    {
        public DateTime? CreatedDate { get; set; }
        public double Total { get; set; }
        public int Status { get; set; }
        public Guid UserId { get; set; }
        public Guid BillId { get; set; }
        public string Username { get; set; } = null!;
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
