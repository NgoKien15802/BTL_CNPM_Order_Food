using OrderFood.Common.Constants;

namespace OrderFood.Common.Models
{
    public class BaseModel
    {
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public string? CreatedBy { get; set; } = SD.CreatedBy;

        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; } = SD.CreatedBy;
    }
}
