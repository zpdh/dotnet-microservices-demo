using Api.Domain.Core;

namespace Api.App.Core.Messaging.Abstractions;

public interface IBaseCommand;

public interface ICommand : IBaseCommand;

public interface ICommand<TResponse> : IBaseCommand;