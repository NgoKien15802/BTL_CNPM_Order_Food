using Microsoft.AspNetCore.Http;
using OrderFood.Common.DTOs;
using OrderFood.Common.DTOs.Auth;
using OrderFood.Common.Models;
using OrderFood.DL.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.Auth
{
    public class AuthBL : IAuthBL
    { 
        private readonly IAuthDL _authDL;

        ServiceResponse<User> _serviceResponse = new ServiceResponse<User>();

        public async Task<ServiceResponse<User>> Login(LoginRequestDto loginRequestDto, HttpContext httpContext)
        {
            var user = await _authDL.CheckLogin(loginRequestDto);
            if (user == null)
            {
                _serviceResponse.Success = false;
                _serviceResponse.Message = "Username or password incorrect";
                return _serviceResponse;
            }
            return _serviceResponse;
            // check password

            // set jwt
        }
    }
}
