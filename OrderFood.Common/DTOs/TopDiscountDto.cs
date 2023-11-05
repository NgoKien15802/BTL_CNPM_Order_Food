namespace OrderFood.Common.DTOs
{
    public class TopDiscountDto
    {
        public Guid FoodId { get; set; } = Guid.NewGuid();

        public string FoodName { get; set; } = "";

        public float FoodDiscount { get; set; }

        // 1 - Special Offer, 2 - Limited Offer
        public int FoodDiscountType { get; set; }

        public string? Url { get; set; }

        public string? FoodDesc { get; set; }
    }
}
