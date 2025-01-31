using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;
using Platform.Api.Domain.Platform;
using Error = Platform.Api.Domain.Core.Error;

namespace Platform.Api.App.Platforms;

public sealed record GetPlatformByIdRequest(int Id);

public sealed record GetPlatformByIdResponse(int Id, string Name, string Publisher);

public sealed record GetPlatformByIdQuery(GetPlatformByIdRequest Request) : IQuery<GetPlatformByIdResponse>;

public class GetPlatformByIdQueryHandler(IRepository<Domain.Platform.Platform> repository)
    : IQueryHandler<GetPlatformByIdQuery, GetPlatformByIdResponse>
{
    private readonly IRepository<Domain.Platform.Platform> _repository = repository;

    public async Task<Result<GetPlatformByIdResponse>> HandleAsync(GetPlatformByIdQuery query)
    {
        var id = query.Request.Id;
        var result = await _repository.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return Result.Failure<GetPlatformByIdResponse>(DomainError.Platform.NotFound(id));
        }

        var response = new GetPlatformByIdResponse(result.Value.Id,
            result.Value.Name,
            result.Value.Publisher);

        return response;
    }
}