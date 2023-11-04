using Microsoft.AspNetCore.Http;
using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.BillBL
{
    public interface IBillBL : IBaseBL<Bill>
    {
        public ServiceResponse<Bill> GetBills();
    }
}
