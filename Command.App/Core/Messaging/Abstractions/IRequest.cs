namespace Command.App.Core.Messaging.Abstractions;

public interface IRequest;

public interface IRequest<TResponse>;

public interface ICommand : IRequest;

public interface ICommand<TResponse> : IRequest<TResponse>;

public interface IQuery<TResponse> : IRequest<TResponse>;