using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Mediator.CQRS.Extensions
{
    public static class GlobalExceptionHandler
    {
        public static void HandleException(this IApplicationBuilder app) 
        {
            app.UseExceptionHandler(o => 
            o.Run(async context => 
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeature.Error;

                if (!(exception is FluentValidation.ValidationException validationException))
                    throw exception;

                var errors = validationException.Errors.Select(error => new
                {
                    Property = error.PropertyName,
                    Message = error.ErrorMessage
                });

                var errorContent = JsonSerializer.Serialize(errors);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorContent, System.Text.Encoding.UTF8);
            }));
        }
    }
}
