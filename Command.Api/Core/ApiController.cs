﻿using Command.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace Command.Api.Core;

[Route("api/[controller]")]
public class ApiController : ControllerBase
{
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