using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class BillDetail
    {
        public Guid BillId { get; set; }
        public Guid FoodId { get; set; }
        public int Quantity { get; set; }

        public virtual Bill Bill { get; set; } = null!;
        public virtual Food Food { get; set; } = null!;
    }
}
