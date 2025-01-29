using Api.App.Core.Messaging.Abstractions;
using Api.Domain.Core;

namespace Api.App.Core.Messaging;


public sealed class Mediator(IServiceProvider services) : IMediator
{
    private readonly IServiceProvider _services = services;

    public Task<Result> Send(ICommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TResponse>> Send<TResponse>(ICommand<TResponse> command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TResponse>> Send<TResponse>(IQuery<TResponse> query)
    {
        throw new NotImplementedException();
    }
}