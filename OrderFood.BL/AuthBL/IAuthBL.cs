using Microsoft.AspNetCore.Http;
using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.BL
{
    public interface IAuthBL : IBaseBL<User>
    {
        public Task<ServiceResponse<User>> Login(LoginRequestDto loginRequestDto, HttpContext httpContext);

        public Task<ServiceResponse<User>> Register(RegisterRequestDto registrationRequestDto);

        public bool checkRole(string jwt);
    }
}
