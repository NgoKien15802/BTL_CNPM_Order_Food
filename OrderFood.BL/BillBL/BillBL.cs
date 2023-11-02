using OrderFood.Common.Models;
using OrderFood.DL.BillDL;
using OrderFood.DL.FoodDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.BillBL
{
    public class BillBL : BaseBL<Bill>, IBillBL
    {
        private IBillDL _billDL;

        public BillBL(IBillDL billDL) : base(billDL)
        {
            _billDL = billDL;
        }
    }
}
