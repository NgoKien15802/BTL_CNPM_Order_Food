using System.ComponentModel.DataAnnotations;

namespace OrderFood.Common.Models
{
    public class Category : BaseModel
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
    }
}
