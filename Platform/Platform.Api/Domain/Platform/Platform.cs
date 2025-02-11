using Platform.Api.Domain.Core;

namespace Platform.Api.Domain.Platform;

public sealed class Platform : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;

    public Platform(string name, string publisher)
    {
        Name = name;
        Publisher = publisher;
    }

    private Platform()
    {

    }
}