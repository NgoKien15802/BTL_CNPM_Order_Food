using OrderFood.Common.DTOs.Auth;
using OrderFood.Common.Models;
using OrderFood.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.DL.Auth
{
    public interface IAuthDL : IBaseDL<User>
    {
        public Task<User> CheckLogin(LoginRequestDto loginRequestDto);
    }
}
