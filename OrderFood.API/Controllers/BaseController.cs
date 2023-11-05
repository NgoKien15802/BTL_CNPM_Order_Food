using Microsoft.AspNetCore.Mvc;
using OrderFood.BL;
using OrderFood.Common.Enums;

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

        [HttpGet("GetAllRecord")]
        public async Task<IActionResult> GetAllRecord(string? recordId = "")
        {
            var resultResponse = await _baseBL.GetAllRecord(recordId);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid recordId)
        {
            var resultResponse = await _baseBL.GetById(recordId);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }

        [HttpPost("addRecord")]
        public IActionResult Add([FromBody] T record)
        {
            var resultResponse = _baseBL.Add(record);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }

        [HttpPut("updateRecord")]
        public IActionResult Update([FromBody] T record)
        {
            var resultResponse = _baseBL.Update(record);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }

        [HttpDelete("deleteById/{recordId}")]
        public async Task<IActionResult> Delete(Guid recordId)
        {
            var resultResponse = await _baseBL.Delete(recordId);
            if (!resultResponse.Success)
            {
                return BadRequest(resultResponse);
            }
            return Ok(resultResponse);
        }
    }
}
