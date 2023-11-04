using OrderFood.Common.DTOs;
using System.Data;

namespace OrderFood.DL
{
    public interface IBaseDL<T>
    {
        public IDbConnection GetOpenConnection();
        int Add(T record);
        int Update(T record);
        public Task<bool> Delete(Guid recordId);
        public Task<T> GetById(Guid recordId);
        public Task<IEnumerable<T>> GetAllRecord(string? recordId = "");
    }
}
