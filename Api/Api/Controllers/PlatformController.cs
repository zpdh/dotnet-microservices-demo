using Api.Api.Core;
using Api.App.Core.Messaging.Abstractions;
using Api.App.Platforms;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers;

public class PlatformController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    [Route("/{id:int}")]
    public async Task<IActionResult> GetPlatformById(int id)
    {
        var request = new GetPlatformByIdRequest(id);
        var query = new GetPlatformByIdQuery(request);

        var result = await Mediator.MediateAsync<GetPlatformByIdQuery, GetPlatformByIdResponse>(query);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlatforms()
    {
        var query = new GetAllPlatformsQuery();

        var result = await Mediator.MediateAsync<GetAllPlatformsQuery, GetAllPlatformsResponse>(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlatform([FromBody] CreatePlatformRequest request)
    {
        var command = new CreatePlatformCommand(request);

        var result = await Mediator.MediateAsync<CreatePlatformCommand, CreatePlatformResponse>(command);

        return Created("", result.Value);
    }
}