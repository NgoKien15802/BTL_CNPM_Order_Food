using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class FoodBL : BaseBL<Food>, IFoodBL
    {
        private IFoodDL _foodDL;
        ServiceResponse<TopDiscountDto> _serviceResponse = new ServiceResponse<TopDiscountDto>();
        ServiceResponse<FoodPayload> _serviceResponseFood = new ServiceResponse<FoodPayload>();

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


        public ServiceResponse<FoodPayload> AddNewFood(FoodPayload foodPayload)
        {
            int numberAffected = _foodDL.AddNewFood(foodPayload);
            if (numberAffected > 0)
            {
                _serviceResponseFood.Success = true;
                _serviceResponseFood.Data = 1;
            }
            else
            {
                _serviceResponseFood.Success = false;
                _serviceResponseFood.Data = 0;
            }
            return _serviceResponseFood;
        }

        public ServiceResponse<FoodPayload> UpdateFood(FoodPayload foodPayload)
        {
            int numberAffected = _foodDL.UpdateFood(foodPayload);
            if (numberAffected > 0)
            {
                _serviceResponseFood.Success = true;
                _serviceResponseFood.Data = 1;
            }
            else
            {
                _serviceResponseFood.Success = false;
                _serviceResponseFood.Data = 0;
            }
            return _serviceResponseFood;
        }
    }
}
