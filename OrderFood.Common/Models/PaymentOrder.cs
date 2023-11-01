using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Common.Models
{
    public class PaymentOrder : BaseModel
    {
        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
        public Payment Payment  { get; set; }


        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

    }
}
