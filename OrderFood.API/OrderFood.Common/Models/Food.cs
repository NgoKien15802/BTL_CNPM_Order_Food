using System;
using System.Collections.Generic;

namespace OrderFood.API.OrderFood.Common.Models
{
    public partial class Food
    {
        public Food()
        {
            FoodImages = new HashSet<FoodImage>();
        }

        public Guid FoodId { get; set; }
        public Guid CategoryId { get; set; }
        public string FoodName { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? FoodDesc { get; set; }
        public float? FoodDiscount { get; set; }
        public float FoodStar { get; set; }
        public string FoodStatus { get; set; } = null!;
        public string FoodType { get; set; } = null!;
        public string? FoodVote { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<FoodImage> FoodImages { get; set; }
    }
}
