using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;

namespace OrderFood.DL
{
    public class RoleDL : BaseDL<Role>, IRoleDL
    {
        public RoleDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
