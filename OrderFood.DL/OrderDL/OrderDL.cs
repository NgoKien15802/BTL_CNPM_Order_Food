using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;
using OrderFood.DL.RoleDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.DL.OrderDL
{
    public class OrderDL : BaseDL<Order>, IOrderDL
    {
        public OrderDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
