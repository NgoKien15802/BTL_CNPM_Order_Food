namespace OrderFood.Common.DTOs
{
    public class FoodPayload
    {
        public Guid? FoodId { get; set; }

        public Guid CategoryId { get; set; }

        public string FoodName { get; set; } = "";

        public float FoodStar { get; set; }

        public string? FoodVote { get; set; }

        public float? FoodDiscount { get; set; }

        public string? FoodDesc { get; set; }

        public string FoodStatus { get; set; } = "";

        public string FoodType { get; set; } = "";

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string? Url { get; set; }

        // 1 - Special Offer, 2 - Limited Offer
        public int? FoodDiscountType { get; set; }
    }
}
