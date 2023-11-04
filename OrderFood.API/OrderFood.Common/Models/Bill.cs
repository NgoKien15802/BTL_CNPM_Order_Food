using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class Bill
    {
        public Guid BillId { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public double Total { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public int? Delivery { get; set; }
        public int? Discount { get; set; }
        public string? Method { get; set; }
        public string? Paid { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
