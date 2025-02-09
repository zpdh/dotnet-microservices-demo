namespace Platform.Api.Domain.Platform;

public interface IPlatformClient
{
    Task SendToCommandAsync(Communication.GetAllPlatformsResponse platforms);
}