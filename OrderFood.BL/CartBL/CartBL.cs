using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
{
    public class CartBL : BaseBL<Cart>, ICartBL
    {

        private ICartDL _cartDL;
        ServiceResponse<CartPayload> _servicePayload = new ServiceResponse<CartPayload>();
        ServiceResponse<CartResponse> _serviceResponse = new ServiceResponse<CartResponse>();

        public CartBL(ICartDL cartDL) : base(cartDL)
        {
            _cartDL = cartDL;
        }

        public async Task<ServiceResponse<CartResponse>> GetCartInfo(Guid userId)
        {
            var records = await _cartDL.GetCartInfo(userId);
            if (records != null)
            {
                _serviceResponse.Success = true;
                _serviceResponse.Data = records;
            }
            else
            {
                _serviceResponse.Success = false;
                _serviceResponse.Data = null;
            }
            return _serviceResponse;
        }

        public ServiceResponse<CartPayload> AddToCart(CartPayload cartPayload)
        {
            int numberAffected = _cartDL.AddToCart(cartPayload);
            if (numberAffected > 0)
            {
                _servicePayload.Success = true;
                _servicePayload.Data = 1;
            }
            else
            {
                _servicePayload.Success = false;
                _servicePayload.Data = 0;
            }
            return _servicePayload;
        }

        public ServiceResponse<CartPayload> RemoveAll(Guid userId)
        {
            int numberAffected = _cartDL.RemoveAll(userId);
            if (numberAffected > 0)
            {
                _servicePayload.Success = true;
                _servicePayload.Data = 1;
            }
            else
            {
                _servicePayload.Success = false;
                _servicePayload.Data = 0;
            }
            return _servicePayload;
        }
    }
}
