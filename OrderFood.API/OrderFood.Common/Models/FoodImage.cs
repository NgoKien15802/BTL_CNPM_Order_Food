using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class FoodImage
    {
        public Guid FoodImageId { get; set; }
        public Guid FoodId { get; set; }
        public string Url { get; set; } = null!;
        public int Type { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Food Food { get; set; } = null!;
    }
}
