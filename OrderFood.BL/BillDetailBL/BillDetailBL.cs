using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class BillDetailBL : BaseBL<BillDetail>, IBillDetailBL
    {
        private IBillDetailDL _billDetailDL;

        public BillDetailBL(IBillDetailDL billDetailDL) : base(billDetailDL)
        {
            _billDetailDL = billDetailDL;
        }
    }
}
