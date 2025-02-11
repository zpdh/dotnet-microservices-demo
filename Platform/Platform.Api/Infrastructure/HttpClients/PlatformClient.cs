using Platform.Api.Api.Core;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Platform;

namespace Platform.Api.Infrastructure.HttpClients;

public class PlatformClient(HttpClient client, IConfiguration configuration) : IPlatformClient
{
    private readonly HttpClient _client = client;

    private const string CommandServiceName = "Commands";
    private readonly string _commandServiceUri = configuration.GetValue<string>("Urls:CommandsService")!;

    public async Task<Result> SendToCommandAsync(Domain.Platform.Platform platform)
    {
        var response = await _client.PostAsJsonAsync($"{_commandServiceUri}/platforms", platform);

        return response.IsSuccessStatusCode
            ? Result.Success()
            : Result.Failure(DomainError.Platform.CouldNotSend(""));
    }
}