using System.Text.Json.Serialization;
using Command.Domain.Core;

namespace Command.Domain.Platform;

public sealed class Platform : Entity
{
  public string Name { get; set; } = string.Empty;
  [JsonIgnore] public ICollection<Command.Command> Commands { get; set; } = [];

  public Platform(string name)
  {
    Name = name;
  }

  private Platform() { }
}

