using Command.Api.Core;
using Command.App.Commands;
using Command.App.Core.Messaging.Abstractions;
using Command.Domain.Command;
using Microsoft.AspNetCore.Mvc;

namespace Command.Api.Controllers;

public class CommandsController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet("platform/{platformId:int}")]
    public async Task<IActionResult> GetAllCommands(int platformId)
    {
        var request = new Communication.GetAllCommandsRequest(platformId);
        var query = new GetAllCommandsQuery(request);

        var result = await Mediator.MediateAsync<GetAllCommandsQuery, Communication.GetAllCommandsResponse>(query);

        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpGet("{commandId:int}/platform/{platformId:int}")]
    public async Task<IActionResult> GetSingleCommand(int commandId, int platformId)
    {
        var request = new Communication.GetSingleCommandRequest(commandId, platformId);
        var query = new GetSingleCommandQuery(request);

        var result = await Mediator.MediateAsync<GetSingleCommandQuery, Communication.GetSingleCommandResponse>(query);

        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpPost("platform/{platformId:int}")]
    public async Task<IActionResult> CreateCommand(int platformId, Communication.CreateCommandRequest request)
    {
        var dto = new Dtos.CreateCommandDto(platformId, request.HowTo, request.CommandLine);
        var command = new CreateCommandCommand(dto);

        var result = await Mediator.MediateAsync(command);

        return result.IsSuccess ? NoContent() : HandleFailure(result);
    }
}