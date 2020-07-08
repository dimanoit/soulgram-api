using Microsoft.AspNetCore.Mvc.Filters;
using Soulgram.Exceptions;
using Soulgram.Model;
using System.Linq;

namespace Soulgram.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorList = context.ModelState.Select(model => new ValidationError(model.Key, model.Value.Errors.Select(err => err.ErrorMessage)));
                throw new ValidationFailedException($"Parameter validation failed", errorList);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
