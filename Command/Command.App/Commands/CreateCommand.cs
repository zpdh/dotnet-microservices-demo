using Command.App.Core.Messaging.Abstractions;
using Command.Domain.Command;
using Command.Domain.Core;
using Command.Domain.Infrastructure.Data;

namespace Command.App.Commands;

public sealed record CreateCommandCommand(Dtos.CreateCommandDto Request) : ICommand;

public sealed record CreateCommandCommandHandler(ICommandRepository commandRepository) : ICommandHandler<CreateCommandCommand>
{
    private readonly ICommandRepository _commandRepository = commandRepository;

    public async Task<Result> HandleAsync(CreateCommandCommand request)
    {
        var command = new Command.Domain.Command.Command(request.Request.PlatformId, request.Request.HowTo, request.Request.CommandLine);
        var result = await _commandRepository.InsertAsync(command, request.Request.PlatformId);

        return result;
    }
}