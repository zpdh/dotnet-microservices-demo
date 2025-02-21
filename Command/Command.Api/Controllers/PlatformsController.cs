using Command.Api.Core;
using Command.App.Core.Messaging.Abstractions;
using Command.App.Platforms;
using Command.Domain.Platform;
using Microsoft.AspNetCore.Mvc;

namespace Command.Api.Controllers;

public class PlatformsController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAllPlatforms()
    {
        var query = new GetAllPlatformsQuery();
        var result = await Mediator.MediateAsync<GetAllPlatformsQuery, Communication.GetAllPlatformsResponse>(query);

        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }
}