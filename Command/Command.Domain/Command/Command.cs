using System.Text.Json.Serialization;
using Command.Domain.Core;

namespace Command.Domain.Command;

public class Command : Entity
{
    public int PlatformId { get; set; }
    public string HowTo { get; set; } = string.Empty;
    public string CommandLine { get; set; } = string.Empty;
    [JsonIgnore] public Platform.Platform Platform { get; set; } = default!;

    public Command(int platformId, string howTo, string commandLine)
    {
        PlatformId = platformId;
        HowTo = howTo;
        CommandLine = commandLine;
    }

    private Command()
    {

    }
}