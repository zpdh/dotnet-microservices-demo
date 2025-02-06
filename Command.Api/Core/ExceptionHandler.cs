using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Command.Api.Core;

public class ExceptionHandler : IExceptionHandler
{

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        const int statusCode = StatusCodes.Status500InternalServerError;

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Type = exception.GetType().Name,
            Title = "An unknown error occurred while handling your request.",
            Detail = exception.Message
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}