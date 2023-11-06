using Dapper;
using Microsoft.Extensions.Configuration;
using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using System.Data;

namespace OrderFood.DL
{
    public class CartDL : BaseDL<Cart>, ICartDL
    {
        public CartDL(IConfiguration configuration) : base(configuration)
        {
        }

        public int AddToCart(CartPayload cartPayload)
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    string storedProcedureName = $"AddToCart";
                    var parameters = new DynamicParameters();
                    var properties = typeof(CartPayload).GetProperties();

                    foreach (var property in properties)
                    {
                        var propertyName = property.Name;
                        dynamic propertyValue;
                        propertyValue = property.GetValue(cartPayload);
                        if (propertyValue != null)
                        {
                            parameters.Add($"@{propertyName}", propertyValue);
                        }
                    }

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

        public async Task<IEnumerable<CartResponse>> GetCartInfo(Guid userId)
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    string storedProcedureName = "GetCartInfo";
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserId", userId);

                    return await connection.QueryAsync<CartResponse>(
                        storedProcedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int RemoveAll(Guid userId)
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    string storedProcedureName = $"RemoveAllCart";
                    var parameters = new DynamicParameters();
                    parameters.Add("UserId", userId);

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
