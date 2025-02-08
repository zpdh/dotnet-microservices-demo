using Command.Api.Core;
using Command.App.Core.Messaging.Abstractions;
using Command.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace Command.Api.Controllers;

public class CommandsController(IMediator mediator) : ApiController(mediator)
{
    
}