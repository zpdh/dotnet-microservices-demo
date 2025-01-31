using Platform.Api.Domain.Core;

namespace Platform.Api.Domain.Platform;

public static class DomainError
{
    public static class Platform
    {
        public static Core.Error NotFound(int id) => new($"Platform with id {id} not found.");
    }
}