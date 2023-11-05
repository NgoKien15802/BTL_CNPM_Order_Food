using Dapper;
using Microsoft.Extensions.Configuration;
using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using System.Data;

namespace OrderFood.DL
{
    public class FoodDL : BaseDL<Food>, IFoodDL
    {
        private readonly AppDBContext _dbContext;

        public FoodDL(IConfiguration configuration, AppDBContext dBContext) : base(configuration)
        {
            _dbContext = dBContext;
        }

        public async Task<List<TopDiscountDto>> GetTopDiscount(int number)
        {
            using (var connection = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Number", number);

                var result = await connection.QueryAsync<TopDiscountDto>(
                    "GetTopDiscount",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }
    }
}
