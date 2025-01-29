using Api.App.Core.Messaging.Abstractions;
using Api.Domain.Core;
using Api.Domain.Infrastructure.Data.Abstractions;
using Api.Domain.Platform;

namespace Api.App.Platforms;

public sealed record CreatePlatformRequest(string Name, string Publisher);

public sealed record CreatePlatformResponse(int Id);

public sealed record CreatePlatformCommand(CreatePlatformRequest Request) : ICommand<CreatePlatformResponse>;

public sealed class CreatePlatformCommandHandler(IRepository<Platform> repository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePlatformCommand, CreatePlatformResponse>
{
    private readonly IRepository<Platform> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreatePlatformResponse>> HandleAsync(CreatePlatformCommand query)
    {
        var entity = new Platform(query.Request.Name, query.Request.Publisher);

        await _repository.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var response = new CreatePlatformResponse(entity.Id);

        return response;
    }
}