using System.ComponentModel.DataAnnotations;

namespace OrderFood.Common.Models
{
    public class Payment : BaseModel
    {
        [Key]
        public Guid PaymentId { get; set; } = Guid.NewGuid();

        // 0 - Thanh toán trực tiếp
        public int Type { get; set; }
    }
}
