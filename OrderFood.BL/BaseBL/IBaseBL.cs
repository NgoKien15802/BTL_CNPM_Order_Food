using OrderFood.Common.DTOs;

namespace OrderFood.BL
{
    public interface IBaseBL<T>
    {
        public Task<ServiceResponse<T>> GetAllRecord();
    }
}
