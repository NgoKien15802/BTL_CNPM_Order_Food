using OrderFood.Common.Enums;

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
