using Microsoft.EntityFrameworkCore;
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

        public async Task<List<string>> GetRoles(User user)
        {
            var roles = await (from u in _dbContext.Users
                               join r in _dbContext.Roles on u.RoleId equals r.RoleId
                               select r.RoleName).ToListAsync(); 
            return roles; 
        }
        public async Task<bool> CheckEmailExists(string email)
        {
            return await _dbContext.Users.AnyAsync(x => x.Email.ToLower().Trim() == email.ToLower().Trim());
        }

        public async Task<string> CreateUser(User user, string roleName)
        {
            var roleExist = await _dbContext.Roles.AnyAsync(x => x.RoleName.ToLower().Trim() == roleName.ToLower().Trim());
            if (!roleExist)
            {
                Role role = new Role()
                {
                    RoleName = roleName,
                };
                _dbContext.Roles.Add(role);
                await _dbContext.SaveChangesAsync();
            }
            Guid roleId = (from r in _dbContext.Roles
                           where r.RoleName == roleName
                           select r.RoleId).FirstOrDefault();
            string success = await CreateUser(user, roleId);
            if (string.IsNullOrEmpty(success))
            {
                return "";
            }
            else
            {
                return success;
            }
        }
        public async Task<string> CreateUser(User user, Guid roleId)
        {
            try
            {
                user.RoleId = roleId;
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
