using Api.App.Core.Messaging.Abstractions;
using Api.Domain.Core;
using Api.Domain.Infrastructure.Data.Abstractions;
using Api.Domain.Platform;
using Error = Api.Domain.Core.Error;

namespace Api.App.Platforms;

public sealed record GetPlatformByIdRequest(int Id);

public sealed record GetPlatformByIdResponse(int Id, string Name, string Publisher);

public sealed record GetPlatformByIdQuery(GetPlatformByIdRequest Request) : IQuery<GetPlatformByIdResponse>;

public class GetPlatformByIdQueryHandler(IRepository<Platform> repository)
    : IQueryHandler<GetPlatformByIdQuery, GetPlatformByIdResponse>
{
    private readonly IRepository<Platform> _repository = repository;

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