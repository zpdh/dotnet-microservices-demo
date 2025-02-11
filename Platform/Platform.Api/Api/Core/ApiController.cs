using Platform.Api.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.App.Core.Messaging.Abstractions;

namespace Platform.Api.Api.Core;

[Route("api/[controller]")]
public class ApiController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;

    protected IActionResult HandleFailure(Result result)
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException("Cannot handle a success' failure."),
            _ => HandleBadRequest(result)
        };
    }

    private BadRequestObjectResult HandleBadRequest(Result result)
    {
        return BadRequest(
            CustomProblemDetails.Create(
                "Bad Request",
                StatusCodes.Status400BadRequest,
                result.Error.ErrorMessage
            ));
    }
}