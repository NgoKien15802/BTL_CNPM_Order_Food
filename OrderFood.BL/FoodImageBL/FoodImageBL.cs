using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class FoodImageBL : BaseBL<FoodImage>, IFoodImageBL
    {
        private IFoodImageDL _foodImageDL;

        public FoodImageBL(IFoodImageDL foodImageDL) : base(foodImageDL)
        {
            _foodImageDL = foodImageDL;
        }
    }
}