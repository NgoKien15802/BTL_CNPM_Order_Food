using Microsoft.AspNetCore.Mvc;
using OrderFood.BL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class FoodsController : BaseController<Food>
    {
        private IFoodBL _foodBL;

        public FoodsController(IFoodBL foodBL) : base(foodBL)
        {
            _foodBL = foodBL;
        }

        [HttpGet("getTopDiscount/{number}")]
        public IActionResult GetTopDiscount(int number)
        {
            var response = _foodBL.GetTopDiscount(number);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
