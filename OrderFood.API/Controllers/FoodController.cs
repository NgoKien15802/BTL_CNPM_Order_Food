using OrderFood.BL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class FoodController : BaseController<Food>
    {
        private IFoodBL _foodBL;

        public FoodController(IFoodBL foodBL) : base(foodBL)
        {
            _foodBL = foodBL;
        }
    }
}
