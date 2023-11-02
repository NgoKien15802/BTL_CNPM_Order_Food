using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using OrderFood.DL.BillDetailDL;
using OrderFood.DL.FoodDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.BillDetailBL
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
