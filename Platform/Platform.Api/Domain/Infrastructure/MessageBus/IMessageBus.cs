using Platform.Api.Domain.Platform;

namespace Platform.Api.Domain.Infrastructure.MessageBus;

public interface IMessageBus
{
    Task PublishPlatformAsync(Communication.PublishPlatformRequest request);
}