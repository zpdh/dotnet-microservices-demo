using Command.App.Core.Messaging.Abstractions;
using Command.Domain.Command;
using Command.Domain.Core;
using Command.Domain.Infrastructure.Data;

namespace Command.App.Commands;

public sealed record GetSingleCommandQuery(Communication.GetSingleCommandRequest Request) : IQuery<Communication.GetSingleCommandResponse>;

public sealed record GetSingleCommandQueryHandler(ICommandRepository commandRepository)
    : IQueryHandler<GetSingleCommandQuery, Communication.GetSingleCommandResponse>
{
    private readonly ICommandRepository _commandRepository = commandRepository;

    public async Task<Result<Communication.GetSingleCommandResponse>> HandleAsync(GetSingleCommandQuery request)
    {
        var result = await _commandRepository.GetByIdAsync(request.Request.CommandId, request.Request.PlatformId);

        if (result.IsFailure)
        {
            return Result.Failure<Communication.GetSingleCommandResponse>(result.Error);
        }

        var response = new Communication.GetSingleCommandResponse(result.Value);
        return response;
    }
}