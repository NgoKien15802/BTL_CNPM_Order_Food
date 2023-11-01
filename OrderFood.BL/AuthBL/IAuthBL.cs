using Microsoft.AspNetCore.Http;
using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.BL
{
    public interface IAuthBL
    {
        public Task<ServiceResponse<User>> Login(LoginRequestDto loginRequestDto, HttpContext httpContext);

        public Task<ServiceResponse<User>> Register(RegisterRequestDto registrationRequestDto);
    }
}
