using Command.App.Core.Messaging.Abstractions;
using Command.Domain.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Command.App.Core.Messaging;

public class Mediator(IServiceProvider serviceProvider) : IMediator
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task<Result> MediateAsync<TRequest>(TRequest request)
        where TRequest : IRequest
    {
        var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest>>();

        return await handler.HandleAsync(request);
    }

    public async Task<Result<TResponse>> MediateAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
    {
        var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

        return await handler.HandleAsync(request);
    }
}