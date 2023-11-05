using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class BillBL : BaseBL<Bill>, IBillBL
    {
        private IBillDL _billDL;
        ServiceResponse<Bill> _serviceResponse = new ServiceResponse<Bill>();

        public BillBL(IBillDL billDL) : base(billDL)
        {
            _billDL = billDL;
        }

        public ServiceResponse<Bill> GetBills()
        {
            var records = _billDL.GetBills();
            if (records != null)
            {
                _serviceResponse.Success = true;
                _serviceResponse.Data = records;
            }
            else
            {
                _serviceResponse.Success = false;
            }
            return _serviceResponse;
        }
    }
}
