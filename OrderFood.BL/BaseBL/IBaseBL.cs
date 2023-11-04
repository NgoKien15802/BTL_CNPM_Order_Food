using OrderFood.Common.DTOs;

namespace OrderFood.BL
{
    public interface IBaseBL<T>
    {
        public Task<ServiceResponse<T>> GetAllRecord(string? recordId = "");

        public Task<ServiceResponse<T>> GetById(Guid recordId);

        public Task<ServiceResponse<T>> Delete(Guid recordId);

    }
}
