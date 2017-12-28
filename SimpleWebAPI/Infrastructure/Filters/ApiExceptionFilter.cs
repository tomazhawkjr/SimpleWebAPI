using SimpleWebAPI.Entities;
using System;
using System.Web.Http.Filters;

namespace SimpleWebAPI.API.Infrastructure.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        //private readonly IRepository<EventLog> _eventLogRepository;

        public ApiExceptionFilter()
        {
           // _eventLogRepository = new RepositoryImpl<EventLog>();
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            var ex = context.Exception;

           // _eventLogRepository.Operation = EnumRecordOperation.Insert;
            //_eventLogRepository.SaveAndUpdate(new EventLog()
            //{
            //    EventDateTime = new DateTime(),
            //    ExceptionType = context.Exception.GetType().ToString(),
            //    StackTrace = ex.StackTrace,
            //    Message = ex.Message
            //});
        }
    }
}