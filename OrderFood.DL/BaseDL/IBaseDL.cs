using System.Data;

namespace OrderFood.DL
{
    public interface IBaseDL<T>
    {
        public IDbConnection GetOpenConnection();

        public int Add(T record);

        public int Update(T record);

        public Task<bool> Delete(Guid recordId);

        public Task<T> GetById(Guid recordId);

        public Task<IEnumerable<T>> GetAllRecord(string? recordId = "");
    }
}
