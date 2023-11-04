using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Common.Models
{
    public class Order : BaseModel
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User? User { get; set; }

        public DateTime PickupDate { get; set; }
    }
}
