using Dapper;
using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;
using System.Data;

namespace OrderFood.DL
{
    public class BillDL : BaseDL<Bill>, IBillDL
    {
        private readonly AppDBContext _dbContext;

        public BillDL(IConfiguration configuration, AppDBContext dBContext) : base(configuration)
        {
            _dbContext = dBContext;
        }

        public List<Bill> GetBills()
        {
            return _dbContext.Bills.ToList();
        }

        public override async Task<Bill> GetById(Guid recordId)
        {
            using (var connection = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", recordId);

                var result = await connection.QueryFirstOrDefaultAsync<Bill>(
                    "GetBillStatus",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
    }
}
