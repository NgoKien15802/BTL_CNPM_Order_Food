using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public interface IFoodDL : IBaseDL<Food>
    {
        public Task<List<TopDiscountDto>> GetTopDiscount(int number);

        public int AddNewFood(FoodPayload foodPayload);
        
        public int UpdateFood(FoodPayload foodPayload);
    }
}
