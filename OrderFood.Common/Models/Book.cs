using System.ComponentModel.DataAnnotations;

namespace OrderFood.Common.Models
{
    public class Book : BaseModel
    {
        [Key]
        public Guid BookID { get; set; } = Guid.NewGuid();

        public string ClientName { get; set; } = "";

        public string ClientPhone { get; set; } = "";

        public string ClientEmail { get; set; } = "";

        public int NumberOfPeople { get; set; }

        public int NumberOfTable { get; set; }

        public string? Note { get; set; }

        public DateTime PickupDate { get; set; }
    }
}
