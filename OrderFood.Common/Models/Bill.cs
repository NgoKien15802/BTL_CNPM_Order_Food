using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Common.Models
{
    public class Bill : BaseModel
    {
        [Key]
        public Guid BillId { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }


        public string? Paid{ get; set; }

        public int Status { get; set; }

        public double Total { get; set; }

        [NotMapped]
        public string? Address { get; set; }
        [NotMapped]
        public string? PhoneNumber { get; set; }

        [NotMapped]
        public string? Method { get; set; }

        [NotMapped]
        public int? Discount { get; set; }

        [NotMapped]
        public int? Delivery { get; set; }
    }
}
