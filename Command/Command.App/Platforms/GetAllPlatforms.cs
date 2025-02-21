using Command.App.Core.Messaging.Abstractions;
using Command.Domain.Core;
using Command.Domain.Infrastructure.Data;
using Command.Domain.Platform;

namespace Command.App.Platforms;

public sealed record GetAllPlatformsQuery : IQuery<Communication.GetAllPlatformsResponse>;

public sealed class GetAllPlatformsQueryHandler(IPlatformRepository repository)
    : IQueryHandler<GetAllPlatformsQuery, Communication.GetAllPlatformsResponse>
{
    private readonly IPlatformRepository _platformRepository = repository;

    public async Task<Result<Communication.GetAllPlatformsResponse>> HandleAsync(GetAllPlatformsQuery request)
    {
        var result = await _platformRepository.GetAllAsync();
        var response = new Communication.GetAllPlatformsResponse(result.Value);

        return response;
    }
}