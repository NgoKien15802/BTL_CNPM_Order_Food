using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Common.Models
{
    public class Cart : BaseModel
    {
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        [ForeignKey("Food")]
        public Guid FoodId { get; set; }

        public int Quantity { get; set; }
    }
}
