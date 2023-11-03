using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public interface IAuthDL : IBaseDL<User>
    {
        public Task<User> CheckLogin(LoginRequestDto loginRequestDto);

        public Task<List<string>> GetRoles(User user);


        public Task<bool> CheckEmailExists(string email);

        public Task<string> CreateUser(User user, string roleName);
    }
}
