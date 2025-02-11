using Platform.Api.Domain.Core;

namespace Platform.Api.Domain.Platform;

public static class DomainError
{
    public static class Platform
    {
        public static Error NotFound(int id) => new($"Platform with id {id} not found.");
        public static Error CouldNotSend(string serviceName) => new($"Could not send platforms to {serviceName} service.");
    }
}