using OrderFood.Common.Models;
using OrderFood.DL;

namespace OrderFood.BL
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
