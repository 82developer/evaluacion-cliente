using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;// ← necesario para acceder a ValidationFailure y Errors
namespace Evaluacion.Api.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException vex)
            {
                var errors = vex.Errors.Select(e => new { field = e.PropertyName, error = e.ErrorMessage });

                context.Result = new BadRequestObjectResult(new
                {
                    message = "Validation failed",
                    errors
                });

                context.ExceptionHandled = true;
            }
        }
    }
}
