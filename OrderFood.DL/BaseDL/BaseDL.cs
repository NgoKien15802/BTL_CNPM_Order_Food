using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OrderFood.DL
{
    public class BaseDL<T> : IBaseDL<T>
    {

        IConfiguration _configuration;
        private readonly string _tableName;

        public BaseDL(IConfiguration configuration)
        {
            _configuration = configuration;
            _tableName = $"{typeof(T).Name}";
        }

        public IDbConnection GetOpenConnection()
        {
            var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            sqlConnection.Open();
            return sqlConnection;
        }

        public string getRecordId()
        {
            return _tableName.Substring(0, _tableName.Length - 1); ;
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                dynamic rowAffect;
                using (var connection = GetOpenConnection())
                {
                    string sql = $"UPDATE {_tableName} SET Property1 = @Property1, Property2 = @Property2, ... WHERE Id = @Id";
                    rowAffect = await connection.ExecuteAsync(sql, entity);
                }

                if (rowAffect > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public async Task<bool> Delete(Guid recordId)
        {
            try
            {
                dynamic rowAffect;
                using (var connection = GetOpenConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@recordId", recordId);
                    string sql = $"DELETE FROM {_tableName} WHERE {getRecordId()}Id = @recordId";
                    rowAffect = await connection.ExecuteAsync(sql, parameters);
                }
                if (rowAffect > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public async Task<IEnumerable<T>> GetAllRecord(string? recordId = "")
        {
            using (var connection = GetOpenConnection())
            {
                if (string.IsNullOrEmpty(recordId))
                {
                    string sql = $"SELECT * FROM View{_tableName}";
                    return await connection.QueryAsync<T>(sql);
                }
                else
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", new Guid(recordId));
                    return await connection.QueryAsync<T>(
                        $"Get{_tableName}s",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
        }

        public virtual async Task<T> GetById(Guid recordId)
        {
            using (var connection = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", recordId);
                return await connection.QueryFirstOrDefaultAsync<T>(
                    $"Get{_tableName}s",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
