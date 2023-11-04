using OrderFood.BL.RoleBL;
using OrderFood.Common.Models;
using OrderFood.DL;
using OrderFood.DL.OrderDL;
using OrderFood.DL.RoleDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.OrderBL
{
    public class OrderBL : BaseBL<Order>, IOrderBL
    {
        private IOrderDL _orderDL;

        public OrderBL(IOrderDL orderDL) : base(orderDL)
        {
            _orderDL = orderDL;
        }
       
    }
}
