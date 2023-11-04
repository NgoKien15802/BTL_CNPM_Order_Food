using OrderFood.BL;
using OrderFood.BL.OrderBL;
using OrderFood.BL.RoleBL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class OrdersController : BaseController<Order>
    {
        private IOrderBL _orderBL;

        public OrdersController(IOrderBL orderBL) : base(orderBL)
        {
            _orderBL = orderBL;
        }
    }
}
