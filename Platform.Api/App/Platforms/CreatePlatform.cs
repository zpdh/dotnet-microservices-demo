using Platform.Api.Domain.Platform;
using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;

namespace Platform.Api.App.Platforms;

public sealed record CreatePlatformRequest(string Name, string Publisher);

public sealed record CreatePlatformResponse(int Id);

public sealed record CreatePlatformCommand(CreatePlatformRequest Request) : ICommand<CreatePlatformResponse>;

public sealed class CreatePlatformCommandHandler(IRepository<Domain.Platform.Platform> repository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePlatformCommand, CreatePlatformResponse>
{
    private readonly IRepository<Domain.Platform.Platform> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreatePlatformResponse>> HandleAsync(CreatePlatformCommand query)
    {
        var entity = new Domain.Platform.Platform(query.Request.Name, query.Request.Publisher);

        await _repository.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var response = new CreatePlatformResponse(entity.Id);

        return response;
    }
}