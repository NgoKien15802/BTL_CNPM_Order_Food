using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Common.Models
{
    public class PaymentOrder : BaseModel
    {
        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
    }
}
