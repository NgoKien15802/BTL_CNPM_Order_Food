using OrderFood.Common.Models;
using OrderFood.DL;
using OrderFood.DL.RoleDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.BL.RoleBL
{
    public class RoleBL : BaseBL<Role>, IRoleBL
    {
        private IRoleDL _roleDL;

        public RoleBL(IRoleDL roleDL) : base(roleDL)
        {
            _roleDL = roleDL;
        }
    }
}
