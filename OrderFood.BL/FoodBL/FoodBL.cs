using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class FoodBL : BaseBL<Food>, IFoodBL
    {
        private IFoodDL _foodDL;

        public FoodBL(IFoodDL foodDL) : base(foodDL)
        {
            _foodDL = foodDL;
        }
    }
}
