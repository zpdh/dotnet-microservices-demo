using Command.Domain.Core;

namespace Command.App.Core.Messaging.Abstractions;

public interface IMediator
{
    Task<Result> MediateAsync<TRequest>(TRequest request)
        where TRequest : IRequest;

    Task<Result<TResponse>> MediateAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>;
}