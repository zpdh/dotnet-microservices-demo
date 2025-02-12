using Command.Api.Core;
using Command.App.Core.Messaging.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Command.Api.Controllers;

public class PlatformsController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost]
    public IActionResult TestConnection()
    {
        Console.WriteLine("Connection @ /platforms POST");

        return Ok("Commands Service connection test");
    }
}