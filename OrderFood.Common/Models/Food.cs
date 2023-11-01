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

        public Category Category { get; set; }

        public string FoodName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
