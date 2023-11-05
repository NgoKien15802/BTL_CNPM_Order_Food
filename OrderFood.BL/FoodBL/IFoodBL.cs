using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.BL
{
    public interface IFoodBL : IBaseBL<Food>
    {
        public ServiceResponse<TopDiscountDto> GetTopDiscount(int number);
    }
}
