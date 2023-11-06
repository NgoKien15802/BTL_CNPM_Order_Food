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

        public int AddNewFood(FoodPayload foodPayload)
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    string storedProcedureName = "AddNewFood";
                    var parameters = new DynamicParameters();

                    parameters.Add("@CategoryId", foodPayload.CategoryId);
                    parameters.Add("@FoodName", foodPayload.FoodName);
                    parameters.Add("@Price", foodPayload.Price);
                    parameters.Add("@Quantity", foodPayload.Quantity);
                    parameters.Add("@FoodDesc", foodPayload.FoodDesc);
                    parameters.Add("@FoodDiscount", foodPayload.FoodDiscount);
                    parameters.Add("@FoodStar", foodPayload.FoodStar);
                    parameters.Add("@FoodStatus", foodPayload.FoodStatus);
                    parameters.Add("@FoodType", foodPayload.FoodType);
                    parameters.Add("@FoodVote", foodPayload.FoodVote);
                    parameters.Add("@FoodDiscountType", foodPayload.FoodDiscountType);
                    parameters.Add("@Url", foodPayload.Url);

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

        public int UpdateFood(FoodPayload foodPayload)
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    string storedProcedureName = "UpdateFood";
                    var parameters = new DynamicParameters();

                    parameters.Add("@FoodId", foodPayload.FoodId);
                    parameters.Add("@CategoryId", foodPayload.CategoryId);
                    parameters.Add("@FoodName", foodPayload.FoodName);
                    parameters.Add("@Price", foodPayload.Price);
                    parameters.Add("@Quantity", foodPayload.Quantity);
                    parameters.Add("@FoodDesc", foodPayload.FoodDesc);
                    parameters.Add("@FoodDiscount", foodPayload.FoodDiscount);
                    parameters.Add("@FoodStar", foodPayload.FoodStar);
                    parameters.Add("@FoodStatus", foodPayload.FoodStatus);
                    parameters.Add("@FoodType", foodPayload.FoodType);
                    parameters.Add("@FoodVote", foodPayload.FoodVote);
                    parameters.Add("@FoodDiscountType", foodPayload.FoodDiscountType);
                    parameters.Add("@Url", foodPayload.Url);

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
