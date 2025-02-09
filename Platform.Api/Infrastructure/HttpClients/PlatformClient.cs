using Platform.Api.Domain.Platform;

namespace Platform.Api.Infrastructure.HttpClients;

public class PlatformClient(HttpClient client, IConfiguration configuration) : IPlatformClient
{
    private readonly HttpClient _client = client;
    private readonly string _commandServiceUri = configuration.GetValue<string>("Urls:CommandsService")!;

    public async Task SendToCommandAsync(Communication.GetAllPlatformsResponse platforms)
    {
        await _client.PostAsJsonAsync($"{_commandServiceUri}/platforms", platforms);
    }
}