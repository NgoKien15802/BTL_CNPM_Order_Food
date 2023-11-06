using OrderFood.Common.Models;
using OrderFood.BL;
using Microsoft.AspNetCore.Mvc;
using OrderFood.Common.DTOs;

namespace OrderFood.API.Controllers
{
    public class CartsController : BaseController<Cart>
    {
        private ICartBL _cartBL;

        public CartsController(ICartBL cartBL) : base(cartBL)
        {
            _cartBL = cartBL;
        }

        [HttpGet("getCartInfo")]
        public async Task<IActionResult> GetCartInfo(Guid userId)
        {
            var resultResponse = await _cartBL.GetCartInfo(userId);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }

        [HttpPost("addToCart")]
        public IActionResult AddToCart([FromBody] CartPayload cartPayload)
        {
            var resultResponse = _cartBL.AddToCart(cartPayload);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }

        [HttpPost("removeAll")]
        public IActionResult RemoveAll([FromBody] Guid userId)
        {
            var resultResponse = _cartBL.RemoveAll(userId);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }

        [HttpPut("updateCart")]
        public IActionResult UpdateCart([FromBody] CartPayload cartPayload)
        {
            var resultResponse = _cartBL.UpdateCart(cartPayload);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }
    }
}
