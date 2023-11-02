using OrderFood.BL;
using OrderFood.BL.BillBL;
using OrderFood.BL.BillDetailBL;
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
