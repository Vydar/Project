using Data.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Data.Filters
{
    public class DuplicateObjectExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is DuplicateObjectException ex)
            {
                context.Result = new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
