using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.Domain.Core;

namespace Platform.Api.App.Core.Messaging;

public class Mediator(IServiceProvider services) : IMediator
{
    private readonly IServiceProvider _services = services;

    public Task<Result> MediateAsync<TRequest>(TRequest request) where TRequest : IRequest
    {
        var handler = _services.GetRequiredService<IRequestHandler<TRequest>>();

        return handler.HandleAsync(request);
    }

    public Task<Result<TResponse>> MediateAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        var handler = _services.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

        return handler.HandleAsync(request);
    }
}