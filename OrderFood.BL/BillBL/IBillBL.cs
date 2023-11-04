using Microsoft.AspNetCore.Http;
using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.BL
{
    public interface IBillBL : IBaseBL<Bill>
    {
        public ServiceResponse<Bill> GetBills();
    }
}
