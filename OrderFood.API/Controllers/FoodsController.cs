using OrderFood.BL;
using OrderFood.BL.FoodBL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class FoodsController : BaseController<Food>
    {

        private IFoodBL _foodBL;

        public FoodsController(IFoodBL foodBL):base(foodBL)
        {
            _foodBL = foodBL;
        }
    }
}
