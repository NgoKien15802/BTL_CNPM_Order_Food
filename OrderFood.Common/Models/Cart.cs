using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Common.Models
{
    public class Cart : BaseModel
    {
        [Key]
        public Guid CartId { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        
        public User User { get; set; }

        [ForeignKey("Food")]
        public Guid FoodId { get; set; }

        public Food Food { get; set; }

        public int Quantity { get; set; }
    }
}
