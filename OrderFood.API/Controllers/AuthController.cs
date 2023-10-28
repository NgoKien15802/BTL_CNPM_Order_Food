using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OrderFood.BL.Auth;
using OrderFood.Common.DTOs.Auth;
using OrderFood.Common.Models;
using System.Security.Claims;
using System.Text;

namespace OrderFood.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBL _authBL;

        public AuthController(IAuthBL authBL)
        {
            _authBL = authBL;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var loginResponse = await _authBL.Login(request, HttpContext);
            if (loginResponse.Success == false)
            {
                return BadRequest(loginResponse);
            }
            return Ok(loginResponse);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var registerResponse = await _authBL.Register(request);
            if (registerResponse.Success == false)
            {
                return BadRequest(registerResponse);
            }
            return Ok(registerResponse);
        }
    }
}
