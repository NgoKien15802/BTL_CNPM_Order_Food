using OrderFood.Common.DTOs;
using System.Data;

namespace OrderFood.DL
{
    public interface IBaseDL<T>
    {
        public IDbConnection GetOpenConnection();

        public Task<T> GetById(Guid recordId);

        public Task<IEnumerable<T>> GetAllRecord();

        Task<bool> Add(T entity);

        Task<bool> Update(T entity);

        public Task<bool> Delete(Guid recordId);
    }
}
