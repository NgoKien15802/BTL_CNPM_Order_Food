using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderFood.Common.Constants;
using OrderFood.Common.DTOs;
using OrderFood.Common.Models;
using OrderFood.DL;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderFood.BL
{
    public class AuthBL : BaseBL<User>, IAuthBL
    {
        private readonly IAuthDL _authDL;
        private readonly IConfiguration _config;
        ServiceResponse<User> _serviceResponse = new ServiceResponse<User>();

        public AuthBL(IConfiguration configuration, IAuthDL authDL) : base(authDL)
        {
            _authDL = authDL;
            _config = configuration;
        }

        public bool checkRole(string jwt)
        {
            string secretKey = _config.GetSection("AppSettings:Secret").Value;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, // Tùy chọn, kiểm tra Issuer nếu cần thiết
                ValidateAudience = false, // Tùy chọn, kiểm tra Audience nếu cần thiết
                ClockSkew = TimeSpan.Zero // Tùy chọn, đặt độ lệch thời gian
            };

            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(jwt, tokenValidationParameters, out securityToken);

            // Bây giờ bạn có thể truy cập các thông tin trong JWT Token thông qua principal.Claims
            foreach (var claim in principal.Claims)
            {
                if (claim.Value == SD.AdminRole)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<ServiceResponse<User>> Login(LoginRequestDto loginRequestDto, HttpContext httpContext)
        {
            var user = await _authDL.CheckLogin(loginRequestDto);
            if (user == null)
            {
                _serviceResponse.Success = false;
                _serviceResponse.Message = "Username incorrect";
                return _serviceResponse;
            }
            // check password
            if (!BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.PasswordHash))
            {
                _serviceResponse.Success = false;
                _serviceResponse.Message = "Password incorrect";
                return _serviceResponse;
            }
            // set jwt
            var roles = await _authDL.GetRoles(user);
            string token = CreateToken(user, roles);

            _serviceResponse.Success = true;
            _serviceResponse.Data = new UserDto()
            {
                UserId = user.UserId,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Avatar = user.Avatar,
                Gender = user.Gender,
                Token = token
            };
            return _serviceResponse;
        }

        public async Task<ServiceResponse<User>> Register(RegisterRequestDto registrationRequestDto)
        {
            if (await _authDL.CheckEmailExists(registrationRequestDto.Email))
            {
                _serviceResponse.Success = false;
                _serviceResponse.Message = "Email đã tồn tại";
                return _serviceResponse;
            }
            User user = new()
            {
                FullName = registrationRequestDto.FullName.ToLower(),
                Username = registrationRequestDto.Username.ToLower(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registrationRequestDto.PasswordHash),
                Email = registrationRequestDto.Email,
                Address = registrationRequestDto.Address,
                Gender = registrationRequestDto.Gender,
                PhoneNumber = registrationRequestDto.PhoneNumber,
            };
            try
            {
                string result = await _authDL.CreateUser(user, SD.UserRole);
                if (!string.IsNullOrEmpty(result))
                {
                    _serviceResponse.Success = false;
                    _serviceResponse.Message = result;
                    return _serviceResponse;
                }
            }
            catch (Exception ex)
            {
                _serviceResponse.Success = false;
                _serviceResponse.Message = ex.Message;
                return _serviceResponse;
                throw;
            }
            _serviceResponse.Success = true;
            return _serviceResponse;
        }

        private string CreateToken(User user, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // ký bằng khóa bí mật
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Secret").Value);

            // để xác thực, ủy quyền theo chuẩn cấu trúc của jwt 
            var claimList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub,user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FullName)
            };

            // add roles
            claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //được sử dụng để cấu hình thông tin cho JWT.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(1),
                //Thông tin về cách JWT sẽ được ký. Ở đây, nó sử dụng HmacSha256Signature và sử dụng khóa bí mật
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            // trả về chuỗi jwt

            return tokenHandler.WriteToken(token);
        }
    }
}
