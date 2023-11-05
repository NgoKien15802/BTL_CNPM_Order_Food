using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Common.Models
{
    public class FoodImage : BaseModel
    {
        [Key]
        public Guid FoodImageId { get; set; } = Guid.NewGuid();

        [ForeignKey("Food")]
        public Guid FoodId { get; set; }

        public Food? Food { get; set; }

        public string Url { get; set; } = "";

        public int? Type { get; set; }

    }
}
