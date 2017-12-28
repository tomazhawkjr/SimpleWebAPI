using SimpleWebAPI.API.Infrastructure.Types;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SimpleWebAPI.API.Infrastructure.Http
{
    public class ServiceHttpResult : IHttpActionResult
    {
        private readonly HttpStatusCode _statusCode;
        private readonly HttpRequestMessage _httpRequest;
        private ServiceResponse _serviceResponse;

        public ServiceResponse ServiceResponse
        {
            get{
                return _serviceResponse;
            } 
            private set
            {
                _serviceResponse = value;
            }
            }

        public ServiceHttpResult(ServiceResponse response, ApiController controller)
        {
            ServiceResponse = response;
            _statusCode = response.StatusCode;
            _httpRequest = controller.Request;
        }

        public ServiceHttpResult(ServiceException response, ApiController controller)
        {
            _serviceResponse = new ServiceResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Data = response,
                Status = ServiceResponseStatus.Error,
                Message = response.Message
            };

            _statusCode = _serviceResponse.StatusCode;
            _httpRequest = controller.Request;
        }

        public ServiceHttpResult(ModelStateDictionary modelState, ApiController controller)
        {
            var errors = modelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            _serviceResponse = new ServiceResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                Data = errors,
                Status = ServiceResponseStatus.Error,
                Message = "Formato de requisição inválido"
            };

            _statusCode = _serviceResponse.StatusCode;
            _httpRequest = controller.Request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_statusCode)
            {
                Content = new ObjectContent<ServiceResponse>(_serviceResponse, new JsonMediaTypeFormatter(), MediaTypeHeaderValue.Parse("application/json")),
                StatusCode = _statusCode,
                RequestMessage = _httpRequest
            };

            return Task.FromResult(response);
        }
    }
}