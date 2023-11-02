using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.Common.Models
{
    public class BillDetail
    {

        [ForeignKey("Bill")]
        public Guid BillId { get; set; }
        public Bill Bill { get; set; }


        [ForeignKey("Food")]
        public Guid FoodId { get; set; }
        public Food Food { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public string? FoodDesc { get; set; }

        [NotMapped]
        public string? Url { get; set; }

        [NotMapped]
        public string? FoodName { get; set; }
    }
}
