using Microsoft.AspNetCore.Mvc;
using OrderFood.BL;
using OrderFood.Common.Models;

namespace OrderFood.API.Controllers
{
    public class BillsController : BaseController<Bill>
    {
        private IBillBL _billBL;

        public BillsController(IBillBL billBL) : base(billBL)
        {
            _billBL = billBL;
        }

        [HttpGet("getBills")]
        public IActionResult GetBills()
        {
            var loginResponse = _billBL.GetBills();
            if (!loginResponse.Success)
            {
                return BadRequest(loginResponse);
            }
            return Ok(loginResponse);
        }
    }
}
