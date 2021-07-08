using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TrueTasksAPI.Helpers
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(new { 
                    Status = exception.Status,
                    Message = exception.Message,
                    Error = exception.ResponseBody
                })
                {
                    StatusCode = (int) exception.Status
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
