using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class FoodBL : BaseBL<Food>, IFoodBL
    {
        private IFoodDL _foodDL;
        ServiceResponse<TopDiscountDto> _serviceResponse = new ServiceResponse<TopDiscountDto>();

        public FoodBL(IFoodDL foodDL) : base(foodDL)
        {
            _foodDL = foodDL;
        }


        public ServiceResponse<TopDiscountDto> GetTopDiscount(int number)
        {
            var records = _foodDL.GetTopDiscount(number);
            if (records != null)
            {
                _serviceResponse.Success = true;
                _serviceResponse.Datas = records.Result;
            }
            else
            {
                _serviceResponse.Success = false;
            }
            return _serviceResponse;
        }
    }
}
