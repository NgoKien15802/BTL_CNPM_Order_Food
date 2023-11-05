using OrderFood.BL;
using OrderFood.BL.FoodImageBL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class FoodImagesController : BaseController<FoodImage>
    {
        private IFoodImageBL _foodImageBL;

        public FoodImagesController(IFoodImageBL foodImageBL) : base(foodImageBL)
        {
            _foodImageBL = foodImageBL;
        }
    }
}
