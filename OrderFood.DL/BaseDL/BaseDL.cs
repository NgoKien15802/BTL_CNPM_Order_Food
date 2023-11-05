using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

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
            return _tableName.Substring(0, _tableName.Length - 1);
        }

        public int Add(T record)
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    string storedProcedureName = $"Add{_tableName}";
                    var parameters = new DynamicParameters();
                    var properties = typeof(T).GetProperties();

                    foreach (var property in properties)
                    {
                        var propertyName = property.Name;
                        var propertyValue = property.GetValue(record);
                        if (propertyValue != null)
                        {
                            parameters.Add($"@{propertyName}", propertyValue);
                        }
                    }

                    // thực hiện câu lệnh sql 
                    int numberAffected = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                    return numberAffected;
                }
            }
            catch (Exception)
            {
                return 0;
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
                    string sql = $"DELETE FROM {_tableName}s WHERE {_tableName}Id = @recordId";
                    rowAffect = await connection.ExecuteAsync(sql, parameters);
                }

                if (rowAffect > 0)
                    return true;
                return false;
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
                var result = await connection.QueryFirstOrDefaultAsync<T>(
                    $"Get{_tableName}s",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public int Update(T record)
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    string storedProcedureName = $"Update{_tableName}";
                    var parameters = new DynamicParameters();
                    var properties = typeof(T).GetProperties();

                    foreach (var property in properties)
                    {
                        var propertyName = property.Name;
                        var propertyValue = property.GetValue(record);
                        if (propertyValue != null)
                        {
                            parameters.Add($"@{propertyName}", propertyValue);
                        }
                    }

                    // thực hiện câu lệnh sql 
                    int numberAffected = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                    return numberAffected;
                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}
