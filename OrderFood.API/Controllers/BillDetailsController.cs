using OrderFood.BL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class BillDetailsController : BaseController<BillDetail>
    {
        private IBillDetailBL _billDetailBL;

        public BillDetailsController(IBillDetailBL billDetailBL) : base(billDetailBL)
        {
            _billDetailBL = billDetailBL;
        }
    }
}
