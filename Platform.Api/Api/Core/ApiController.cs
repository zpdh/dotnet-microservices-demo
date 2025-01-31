using Platform.Api.Domain.Core;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.App.Core.Messaging.Abstractions;

namespace Platform.Api.Api.Core;

[Route("api/[controller]")]
public class ApiController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}