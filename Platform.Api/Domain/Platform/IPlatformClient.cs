using Platform.Api.Domain.Core;

namespace Platform.Api.Domain.Platform;

public interface IPlatformClient
{
    Task<Result> SendToCommandAsync(Platform platform);
}