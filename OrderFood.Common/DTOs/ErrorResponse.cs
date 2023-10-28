using OrderFood.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.Common.DTOs
{
    public class ErrorResponse
    {
        public ErrorCode ErrCode { get; set; }
        public string DevMessage { get; set; }
        public string UserMessage { get; set; }
        public string TraceID { get; set; }
    }
}
