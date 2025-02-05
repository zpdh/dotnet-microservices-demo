﻿using Microsoft.AspNetCore.Mvc;
using Platform.Api.Api.Core;
using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.App.Platforms;

namespace Platform.Api.Api.Controllers;

public class PlatformController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetPlatformById(int id)
    {
        var request = new GetPlatformByIdRequest(id);
        var query = new GetPlatformByIdQuery(request);

        var result = await Mediator.MediateAsync<GetPlatformByIdQuery, GetPlatformByIdResponse>(query);

        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlatforms()
    {
        var query = new GetAllPlatformsQuery();

        var result = await Mediator.MediateAsync<GetAllPlatformsQuery, GetAllPlatformsResponse>(query);

        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlatform([FromBody] CreatePlatformRequest request)
    {
        var command = new CreatePlatformCommand(request);

        var result = await Mediator.MediateAsync<CreatePlatformCommand, CreatePlatformResponse>(command);

        return result.IsSuccess ? Created("", result.Value) : HandleFailure(result);
    }
}