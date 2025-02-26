using System.Text;
using RabbitMQ.Client;

namespace Platform.Api.Infrastructure.Messaging;

public sealed class ExchangeTypes
{
    public const string FanoutExchange = "trigger";
}

public interface IMessagePublisher
{
    Task PublishAsync(string message);
}

public class MessagePublisher(IConnectionFactory connectionFactory) : IMessagePublisher, IDisposable, IAsyncDisposable
{
    private readonly IConnectionFactory _connectionFactory = connectionFactory;

    private IConnection? Connection { get; set; }
    private IChannel? Channel { get; set; }

    public async Task PublishAsync(string message)
    {
        var channel = await GetFanoutChannelAsync();
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(exchange: ExchangeTypes.FanoutExchange,
            routingKey: string.Empty,
            mandatory: true,
            basicProperties: new BasicProperties(),
            body: body);
    }

    private async Task<IConnection> GetConnectionAsync()
    {
        if (Connection is null || !Connection.IsOpen)
        {
            Connection = await _connectionFactory.CreateConnectionAsync();
        }

        return Connection;
    }

    private async Task<IChannel> GetFanoutChannelAsync()
    {
        if (Channel is null || !Channel.IsOpen)
        {
            var connection = await GetConnectionAsync();
            Channel = await connection.CreateChannelAsync();
            await Channel.ExchangeDeclareAsync(ExchangeTypes.FanoutExchange, ExchangeType.Fanout);
        }

        return Channel;
    }

    public void Dispose()
    {
        if (Connection != null)
        {
            Connection.CloseAsync().GetAwaiter().GetResult();
            Connection.Dispose();
        }

        if (Channel != null)
        {
            Channel.CloseAsync().GetAwaiter().GetResult();
            Channel.Dispose();
        }

        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        if (Connection != null)
        {
            await Connection.CloseAsync();
            await Connection.DisposeAsync();
        }

        if (Channel != null)
        {
            await Channel.CloseAsync();
            await Channel.DisposeAsync();
        }

        GC.SuppressFinalize(this);
    }
}