using Api.App.Core.Messaging.Abstractions;
using Api.Domain.Core;
using Api.Domain.Infrastructure.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Core;

[Route("api/[controller]")]
public class ApiController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}