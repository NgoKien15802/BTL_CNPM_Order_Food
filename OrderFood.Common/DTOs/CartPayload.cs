namespace OrderFood.Common.DTOs
{
    public class CartPayload
    {
        public Guid? CartId { get; set; }

        public Guid UserId { get; set; }

        public Guid FoodId { get; set; }

        public int Quantity { get; set; }
    }
}
