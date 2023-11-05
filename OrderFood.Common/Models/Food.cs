using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Common.Models
{
    public class Food : BaseModel
    {
        [Key]
        public Guid FoodId { get; set; } = Guid.NewGuid();

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }

        public string FoodName { get; set; } = "";

        public float FoodStar { get; set; }

        public string? FoodVote { get; set; }

        public float? FoodDiscount { get; set; }

        public string? FoodDesc { get; set; }

        public string FoodStatus { get; set; } = ""; 

        public string FoodType { get; set; } = "";

        public double Price { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public string? Name { get; set; }

        [NotMapped]
        public string? Url { get; set; }

        // 1 - Special Offer, 2 - Limited Offer
        public int? FoodDiscountType { get; set; }
    }
}
