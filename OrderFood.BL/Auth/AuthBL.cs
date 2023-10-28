using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderFood.Common.Constants;
using OrderFood.Common.DTOs;
using OrderFood.Common.DTOs.Auth;
using OrderFood.Common.Models;
using OrderFood.DL.Auth;
using OrderFood.DL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.Auth
{
    public class AuthBL : IAuthBL
    { 
        private readonly IAuthDL _authDL;
        private readonly IConfiguration _config;


        ServiceResponse<User> _serviceResponse = new ServiceResponse<User>();

        public AuthBL(IConfiguration configuration, IAuthDL authDL)
        {
            _authDL = authDL;
            _config = configuration;
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
                UserId=user.UserId,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Avatar = user.Avatar,
                Gender = user.Gender,
                token = token
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
            List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FullName)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
