using Microsoft.Extensions.Configuration;
using OrderFood.Common.DTOs.Auth;
using OrderFood.Common.Models;
using OrderFood.DL.BaseDL;
using OrderFood.DL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.DL.Auth
{
    public class AuthDL : BaseDL<User>, IAuthDL
    {
        private readonly AppDBContext _dbContext;
        private readonly IConfiguration _config;

        public AuthDL(AppDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _config = configuration;
        }

        public async Task<User> CheckLogin(LoginRequestDto loginRequestDto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username.ToLower() == loginRequestDto.Username.ToLower());
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
