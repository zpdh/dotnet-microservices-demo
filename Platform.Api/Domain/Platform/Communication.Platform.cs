namespace Platform.Api.Domain.Platform;

public static class Communication
{
    public sealed record CreatePlatformRequest(string Name, string Publisher);

    public sealed record CreatePlatformResponse(int Id);

    public sealed record GetAllPlatformsResponse(List<Domain.Platform.Platform> Platforms);

    public sealed record GetPlatformByIdRequest(int Id);

    public sealed record GetPlatformByIdResponse(int Id, string Name, string Publisher);
}