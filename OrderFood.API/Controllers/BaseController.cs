using Microsoft.AspNetCore.Mvc;
using OrderFood.BL;

namespace OrderFood.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region GET
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        #endregion

        #region POST

        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion
    }
}
