using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.BL
{
    public interface ICartBL : IBaseBL<Cart>
    {
        public ServiceResponse<CartPayload> AddToCart(CartPayload cartPayload);

        public Task<ServiceResponse<CartResponse>> GetCartInfo(Guid userId);

        public ServiceResponse<CartPayload> RemoveAll(Guid userId);

        public ServiceResponse<CartPayload> UpdateCart(CartPayload cartPayload);
    }
}
