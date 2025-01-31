using Platform.Api.Domain.Core;

namespace Platform.Api.App.Core.Messaging.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>;