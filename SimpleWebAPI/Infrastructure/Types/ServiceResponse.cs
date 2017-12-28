using System.Net;

namespace SimpleWebAPI.API.Infrastructure.Types
{
    public class ServiceResponse
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ServiceResponseStatus Status { get; set; }
    }

    public enum ServiceResponseStatus
    {
        Success = 1,
        Error = 0
    }

}