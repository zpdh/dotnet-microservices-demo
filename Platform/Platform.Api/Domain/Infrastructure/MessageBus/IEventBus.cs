using Platform.Api.Domain.Platform;

namespace Platform.Api.Domain.Infrastructure.MessageBus;

public interface IEventBus
{
    Task PublishPlatformAsync(Communication.PublishPlatformRequest request);
}