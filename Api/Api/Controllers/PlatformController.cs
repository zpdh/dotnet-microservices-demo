using Api.Api.Core;
using Api.Domain.Infrastructure.Data.Abstractions;
using Api.Domain.Platform;

namespace Api.Api.Controllers;

public class PlatformController(IRepository<Platform> repository) : ApiController
{
    private readonly IRepository<Platform> _repository = repository;
    
}