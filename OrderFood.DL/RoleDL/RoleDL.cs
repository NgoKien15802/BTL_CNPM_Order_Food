using Microsoft.Extensions.Configuration;
using OrderFood.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.DL.RoleDL
{
    public class RoleDL : BaseDL<Role>, IRoleDL
    {
        public RoleDL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
