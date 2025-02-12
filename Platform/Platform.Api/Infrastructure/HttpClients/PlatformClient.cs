using Platform.Api.Api.Core;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Platform;

namespace Platform.Api.Infrastructure.HttpClients;

public class PlatformClient(HttpClient client) : IPlatformClient
{
    private readonly HttpClient _client = client;

    public async Task<Result> SendToCommandAsync(Domain.Platform.Platform platform)
    {
        var response = await _client.PostAsJsonAsync("platforms", platform);

        return response.IsSuccessStatusCode
            ? Result.Success()
            : Result.Failure(DomainError.Platform.CouldNotSend("Commands"));
    }
}