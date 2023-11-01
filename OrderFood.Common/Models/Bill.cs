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


        public int Status { get; set; }

        public double Total { get; set; }
    }
}
