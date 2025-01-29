using Api.Domain.Core;

namespace Api.App.Core.Messaging.Abstractions;

public interface IMediator
{
    Task<Result> Send(ICommand command);
    Task<Result<TResponse>> Send<TResponse>(ICommand<TResponse> command);
    Task<Result<TResponse>> Send<TResponse>(IQuery<TResponse> query);
}