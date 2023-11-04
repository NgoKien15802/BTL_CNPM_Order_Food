using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
