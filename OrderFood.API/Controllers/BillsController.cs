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
            var response = _billBL.GetBills();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
