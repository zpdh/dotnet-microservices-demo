using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;
using Platform.Api.Domain.Platform;

namespace Platform.Api.App.Platforms;

public sealed record GetPlatformByIdQuery(Communication.GetPlatformByIdRequest Request) : IQuery<Communication.GetPlatformByIdResponse>;

public class GetPlatformByIdQueryHandler(IRepository<Domain.Platform.Platform> repository)
    : IQueryHandler<GetPlatformByIdQuery, Communication.GetPlatformByIdResponse>
{
    private readonly IRepository<Domain.Platform.Platform> _repository = repository;

    public async Task<Result<Communication.GetPlatformByIdResponse>> HandleAsync(GetPlatformByIdQuery query)
    {
        var id = query.Request.Id;
        var result = await _repository.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return Result.Failure<Communication.GetPlatformByIdResponse>(DomainError.Platform.NotFound(id));
        }

        var response = new Communication.GetPlatformByIdResponse(result.Value.Id,
            result.Value.Name,
            result.Value.Publisher);

        return response;
    }
}