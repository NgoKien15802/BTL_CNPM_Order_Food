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
        [HttpGet("GetAllRecord")]
        public async Task<IActionResult> GetAllRecord()
        {
            var loginResponse = await _baseBL.GetAllRecord();
            if (!loginResponse.Success)
            {
                return BadRequest(loginResponse);
            }
            return Ok(loginResponse);
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
