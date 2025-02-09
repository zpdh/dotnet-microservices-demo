using Platform.Api.Domain.Platform;
using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;

namespace Platform.Api.App.Platforms;

public sealed record GetAllPlatformsQuery : IQuery<Communication.GetAllPlatformsResponse>;

public sealed class GetAllPlatformsQueryHandler(IRepository<Domain.Platform.Platform> repository)
    : IQueryHandler<GetAllPlatformsQuery, Communication.GetAllPlatformsResponse>
{
    private readonly IRepository<Domain.Platform.Platform> _repository = repository;

    public async Task<Result<Communication.GetAllPlatformsResponse>> HandleAsync(GetAllPlatformsQuery query)
    {
        var result = await _repository.GetAllAsync();
        
        var response = new Communication.GetAllPlatformsResponse(result.Value);

        return response;
    }
}