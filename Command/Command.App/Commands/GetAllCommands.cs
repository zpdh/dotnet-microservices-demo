using Command.App.Core.Messaging.Abstractions;
using Command.Domain.Command;
using Command.Domain.Core;
using Command.Domain.Infrastructure.Data;

namespace Command.App.Commands;

public sealed record GetAllCommandsQuery(Communication.GetAllCommandsRequest Request)
    : IQuery<Communication.GetAllCommandsResponse>;

public sealed class GetAllCommandsQueryHandler(ICommandRepository commandRepository)
    : IQueryHandler<GetAllCommandsQuery, Communication.GetAllCommandsResponse>
{
    private readonly ICommandRepository _commandRepository = commandRepository;

    public async Task<Result<Communication.GetAllCommandsResponse>> HandleAsync(GetAllCommandsQuery request)
    {
        var result = await _commandRepository.GetAllCommandsAsync(request.Request.PlatformId);
        var response = new Communication.GetAllCommandsResponse(result);

        return response;
    }
}