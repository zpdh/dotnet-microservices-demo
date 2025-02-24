namespace Command.Domain.Command;

public static class Communication
{
    public sealed record GetAllCommandsRequest(int PlatformId);

    public sealed record GetAllCommandsResponse(List<Command> Commands);

    public sealed record GetSingleCommandRequest(int CommandId, int PlatformId);

    public sealed record GetSingleCommandResponse(Command Command);

    public sealed record CreateCommandRequest(string HowTo, string CommandLine);
}