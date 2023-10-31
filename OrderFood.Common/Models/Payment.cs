using System.ComponentModel.DataAnnotations;

namespace OrderFood.Common.Models
{
    public class Payment : BaseModel
    {
        [Key]
        public Guid PaymentId { get; set; } = Guid.NewGuid();

        public DateTime Date { get; set; }

        public int Type { get; set; }
    }
}
