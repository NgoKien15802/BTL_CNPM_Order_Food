using OrderFood.Common.Models;

namespace OrderFood.Common.DTOs
{
    public class CartResponse : BaseModel
    {
        public Guid CartId { get; set; }

        public Guid UserId { get; set; }

        public Guid FoodId { get; set; }

        public int Quantity { get; set; }

        public Guid CategoryId { get; set; }

        public string FoodName { get; set; } = "";

        public float FoodStar { get; set; }

        public string? FoodVote { get; set; }

        public float? FoodDiscount { get; set; }

        public string? FoodDesc { get; set; }

        public string FoodStatus { get; set; } = "";

        public string FoodType { get; set; } = "";

        public double Price { get; set; }

        // 1 - Special Offer, 2 - Limited Offer
        public int? FoodDiscountType { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        public string? Url { get; set; }
    }
}
