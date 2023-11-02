using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;
using OrderFood.DL.BillDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.DL.BillDetailDL
{
    public class BillDetailDL : BaseDL<BillDetail>, IBillDetailDL
    {
        public BillDetailDL(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
