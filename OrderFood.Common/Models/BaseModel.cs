using OrderFood.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.Common.Models
{
    public class BaseModel
    {
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = SD.CreatedBy;
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; } = SD.CreatedBy;
    }
}
