using Microsoft.AspNetCore.Http;
using OrderFood.Common.DTOs;
using OrderFood.Common.DTOs.Auth;
using OrderFood.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.Auth
{
    public interface IAuthBL
    {
        public Task<ServiceResponse<User>> Login(LoginRequestDto loginRequestDto, HttpContext httpContext);

        public Task<ServiceResponse<User>> Register(RegisterRequestDto registrationRequestDto);
    }
}
