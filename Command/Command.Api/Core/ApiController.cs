using Command.App.Core.Messaging.Abstractions;
using Command.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace Command.Api.Core;

[Route("api/c/[controller]")]
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
        return BadRequest(CustomProblemDetails.Create(
            "BadRequest",
            StatusCodes.Status400BadRequest,
            result.Error.ErrorMessage
        ));
    }
}