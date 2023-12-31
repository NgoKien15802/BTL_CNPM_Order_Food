﻿using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
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
