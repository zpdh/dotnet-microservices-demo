namespace Command.Domain.Platform;

public static class Communication
{
    public sealed record GetAllPlatformsResponse(List<Platform> Platforms);
}