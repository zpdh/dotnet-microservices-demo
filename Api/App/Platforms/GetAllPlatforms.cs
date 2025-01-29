using Api.App.Core.Messaging.Abstractions;
using Api.Domain.Core;
using Api.Domain.Infrastructure.Data.Abstractions;
using Api.Domain.Platform;

namespace Api.App.Platforms;

public sealed record GetAllPlatformsResponse(List<Platform> Platforms);

public sealed record GetAllPlatformsQuery : IQuery<GetAllPlatformsResponse>;

public sealed class GetAllPlatformsQueryHandler(IRepository<Platform> repository)
    : IQueryHandler<GetAllPlatformsQuery, GetAllPlatformsResponse>
{
    private readonly IRepository<Platform> _repository = repository;

    public async Task<Result<GetAllPlatformsResponse>> HandleAsync(GetAllPlatformsQuery query)
    {
        var result = await _repository.GetAllAsync();
        
        var response = new GetAllPlatformsResponse(result.Value);

        return response;
    }
}