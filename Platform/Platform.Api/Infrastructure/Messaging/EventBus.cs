using System.Text.Json;
using Platform.Api.Domain.Infrastructure.MessageBus;
using Platform.Api.Domain.Platform;
using RabbitMQ.Client;

namespace Platform.Api.Infrastructure.Messaging;

public sealed class EventBus(IEventPublisher eventPublisher) : IEventBus
{
    private readonly IEventPublisher _eventPublisher = eventPublisher;

    public async Task PublishPlatformAsync(Communication.PublishPlatformRequest request)
    {
        var message = JsonSerializer.Serialize(request);
        await _eventPublisher.PublishAsync(message);
    }
}