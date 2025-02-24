namespace Command.Domain.Command;

public static class Dtos
{
    public sealed record CreateCommandDto(int PlatformId, string HowTo, string CommandLine);
}