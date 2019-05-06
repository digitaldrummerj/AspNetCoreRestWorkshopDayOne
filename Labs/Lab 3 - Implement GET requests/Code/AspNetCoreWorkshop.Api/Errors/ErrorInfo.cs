using System.Collections.Generic;

namespace AspNetCoreWorkshop.Api.Errors
{
    public class ErrorInfo
    {
        public ErrorInfo(string message, List<ErrorDetail> details)
        {
            Message = message;
            Details = details;
        }

        public string Message { get; }

        public List<ErrorDetail> Details { get; }
    }
}
