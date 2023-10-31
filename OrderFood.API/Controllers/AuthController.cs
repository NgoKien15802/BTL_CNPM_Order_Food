using Microsoft.AspNetCore.Mvc;
using OrderFood.BL;
using OrderFood.Common.DTOs;

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
            if (!loginResponse.Success)
            {
                return BadRequest(loginResponse);
            }
            return Ok(loginResponse);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var registerResponse = await _authBL.Register(request);
            if (!registerResponse.Success)
            {
                return BadRequest(registerResponse);
            }
            return Ok(registerResponse);
        }
    }
}
