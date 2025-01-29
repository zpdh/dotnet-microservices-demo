using Api.Domain.Core;

namespace Api.App.Core.Messaging.Abstractions;

public interface IRequestHandler<in TRequest> where TRequest : IRequest
{
    Task<Result> HandleAsync(TRequest request);
}

public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<Result<TResponse>> HandleAsync(TRequest request);
}