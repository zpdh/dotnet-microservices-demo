using Platform.Api.Domain.Platform;

namespace Platform.Api.Infrastructure.HttpClients;

public class PlatformClient(HttpClient client) : IPlatformClient
{
    private readonly HttpClient _client = client;

    public async Task SendToCommandAsync(Communication.GetAllPlatformsResponse platforms)
    {
        var response = await _client.PostAsJsonAsync("TODO: Add Command URI", platforms);
    }
}