using System.Text.Json;
using Platform.Api.Domain.Infrastructure.MessageBus;
using Platform.Api.Domain.Platform;
using RabbitMQ.Client;

namespace Platform.Api.Infrastructure.Messaging;

public sealed class MessageBus(IMessagePublisher messagePublisher) : IMessageBus
{
    private readonly IMessagePublisher _messagePublisher = messagePublisher;

    public async Task PublishPlatformAsync(Communication.PublishPlatformRequest request)
    {
        var message = JsonSerializer.Serialize(request);
        await _messagePublisher.PublishAsync(message);
    }
}