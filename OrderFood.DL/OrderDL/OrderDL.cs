using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public class OrderDL : BaseDL<Order>, IOrderDL
    {
        public OrderDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
