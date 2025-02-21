using Command.Domain.Core;

namespace Command.Domain.Command;

public static class Errors
{
    public static class Command
    {
        public static Error PlatformDoesntExist(int platformId) => new($"The platform with id {platformId} does not exist in our system.");
    }
}