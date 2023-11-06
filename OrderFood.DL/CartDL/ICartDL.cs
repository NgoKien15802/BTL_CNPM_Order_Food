using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public interface ICartDL : IBaseDL<Cart>
    {
        public int AddToCart(CartPayload cartPayload);

        public Task<IEnumerable<CartResponse>> GetCartInfo(Guid userId);

        public int RemoveAll(Guid userId);

        public int UpdateCart(CartPayload cartPayload);
    }
}
