using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public class BillDetailDL : BaseDL<BillDetail>, IBillDetailDL
    {
        public BillDetailDL(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
