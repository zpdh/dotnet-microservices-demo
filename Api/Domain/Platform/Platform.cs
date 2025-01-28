using Api.Domain.Core;

namespace Api.Domain.Platform;

public class Platform : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
}