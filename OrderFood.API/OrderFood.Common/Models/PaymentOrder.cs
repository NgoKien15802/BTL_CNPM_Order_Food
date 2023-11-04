using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class PaymentOrder
    {
        public Guid PaymentId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Payment Payment { get; set; } = null!;
    }
}
