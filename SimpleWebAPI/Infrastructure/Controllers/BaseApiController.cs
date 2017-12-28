using SimpleWebAPI.API.Identity;
using SimpleWebAPI.API.Infrastructure.Types;
using SimpleWebAPI.API.Infrastructure.Http;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web.Http.Description;

namespace SimpleWebAPI.API.Infrastructure.Controllers
{
    public class BaseApiController : ApiController
    {

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private readonly ApplicationRoleManager _appRoleManager;

        public BaseApiController()
        {
        }

        public BaseApiController(ApplicationUserManager userManager, ApplicationRoleManager appRoleManager)
        {
            _userManager = userManager;
            _appRoleManager = appRoleManager;
        }

        protected ApplicationRoleManager RoleManager => _appRoleManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationRoleManager>();

        [ResponseType(typeof(ServiceResponse))]
        public ServiceHttpResult Success(string message)
        {
            return new ServiceHttpResult(new ServiceResponse
            {
                StatusCode = HttpStatusCode.OK,
                Data = null,
                Message = message,
                Status = ServiceResponseStatus.Success
            }, this);
        }

        [ResponseType(typeof(ServiceResponse))]
        public ServiceHttpResult Success(string message, object data)
        {
            return new ServiceHttpResult(new ServiceResponse
            {
                StatusCode = HttpStatusCode.OK,
                Data = data,
                Message = message,
                Status = ServiceResponseStatus.Success
            }, this);
        }

        [ResponseType(typeof(ServiceResponse))]
        public ServiceHttpResult Error(string message)
        {
            return new ServiceHttpResult(new ServiceException(message), this);
        }

        [ResponseType(typeof(ServiceResponse))]
        public ServiceHttpResult Error(string message, Exception innerException)
        {
            return new ServiceHttpResult(new ServiceException(message, innerException), this);
        }

        [ResponseType(typeof(ServiceResponse))]
        public ServiceHttpResult Error(ServiceException exception)
        {
            return new ServiceHttpResult(exception, this);
        }

        [ResponseType(typeof(ServiceResponse))]
        public ServiceHttpResult Error(ModelStateDictionary modelState)
        {
            return new ServiceHttpResult(modelState, this);
        }
    }
}
