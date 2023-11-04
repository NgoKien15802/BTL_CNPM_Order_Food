using OrderFood.BL;
using OrderFood.BL.RoleBL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class RolesController : BaseController<Role>
    {
        private IRoleBL _roleBL;

        public RolesController(IRoleBL roleBL) : base(roleBL)
        {
            _roleBL = roleBL;
        }
    }
}
