using Platform.Api.Domain.Platform;
using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;

namespace Platform.Api.App.Platforms;

public sealed record GetAllPlatformsResponse(List<Domain.Platform.Platform> Platforms);

public sealed record GetAllPlatformsQuery : IQuery<GetAllPlatformsResponse>;

public sealed class GetAllPlatformsQueryHandler(IRepository<Domain.Platform.Platform> repository)
    : IQueryHandler<GetAllPlatformsQuery, GetAllPlatformsResponse>
{
    private readonly IRepository<Domain.Platform.Platform> _repository = repository;

    public async Task<Result<GetAllPlatformsResponse>> HandleAsync(GetAllPlatformsQuery query)
    {
        var result = await _repository.GetAllAsync();
        
        var response = new GetAllPlatformsResponse(result.Value);

        return response;
    }
}