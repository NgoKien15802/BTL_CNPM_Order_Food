using OrderFood.BL.BillBL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class BillsController : BaseController<Bill>
    {
        private IBillBL _billBL;

        public BillsController(IBillBL billBL) : base(billBL)
        {
            _billBL = billBL;
        }
    }
}
