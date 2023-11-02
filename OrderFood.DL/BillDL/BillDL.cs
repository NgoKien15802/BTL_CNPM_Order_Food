using Dapper;
using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;
using OrderFood.DL.FoodDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.DL.BillDL
{
    public class BillDL : BaseDL<Bill>, IBillDL
    {
        public BillDL(IConfiguration configuration) : base(configuration)
        {

        }

        public override async Task<Bill> GetById(Guid recordId)
        {
            using (var connection = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", recordId);
                return await connection.QueryFirstOrDefaultAsync<Bill>(
                    "GetBillStatus",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
        }
    }
    }
}
