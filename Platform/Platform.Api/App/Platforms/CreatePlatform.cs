using Platform.Api.Domain.Platform;
using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;
using Platform.Api.Domain.Infrastructure.MessageBus;

namespace Platform.Api.App.Platforms;

public sealed record CreatePlatformCommand(Communication.CreatePlatformRequest Request) : ICommand<Communication.CreatePlatformResponse>;

public sealed class CreatePlatformCommandHandler(
    IRepository<Domain.Platform.Platform> repository,
    IUnitOfWork unitOfWork,
    IMessageBus messageBus
)
    : ICommandHandler<CreatePlatformCommand, Communication.CreatePlatformResponse>
{
    private readonly IRepository<Domain.Platform.Platform> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMessageBus _messageBus = messageBus;

    public async Task<Result<Communication.CreatePlatformResponse>> HandleAsync(CreatePlatformCommand query)
    {
        var entity = new Domain.Platform.Platform(query.Request.Name, query.Request.Publisher);

        await _repository.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var publishRequest = new Communication.PublishPlatformRequest(entity.Id, entity.Name, Events.Platform.Published);
        await _messageBus.PublishPlatformAsync(publishRequest);

        var response = new Communication.CreatePlatformResponse(entity.Id);

        return response;
    }
}