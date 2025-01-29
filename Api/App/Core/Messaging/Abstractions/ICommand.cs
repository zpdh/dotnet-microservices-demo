namespace Api.App.Core.Messaging.Abstractions;

public interface ICommand : IRequest;

public interface ICommand<TResponse> : IRequest<TResponse>;