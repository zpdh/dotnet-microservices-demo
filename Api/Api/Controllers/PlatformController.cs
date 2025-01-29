using Api.Api.Core;
using Api.App.Core.Messaging.Abstractions;
using Api.App.Platforms;
using Api.Domain.Platform;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers;

public class PlatformController : ApiController
{
    [Route("/{id:int}")]
    public async Task<IActionResult> GetPlatformById(
        [FromServices] IQueryHandler<GetPlatformByIdQuery, GetPlatformByIdResponse> queryHandler,
        [FromRoute] int id)
    {
        var request = new GetPlatformByIdRequest(id);
        var query = new GetPlatformByIdQuery(request);

        var result = await queryHandler.HandleAsync(query);

        return Ok(result);
    }
}