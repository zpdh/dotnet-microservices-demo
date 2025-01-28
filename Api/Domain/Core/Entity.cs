using System.Diagnostics.CodeAnalysis;

namespace Api.Domain.Core;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private init; }

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity()
    {

    }

    public bool Equals(Entity? other)
    {
        if (IsNullOrDifferentType(other))
        {
            return false;
        }

        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (IsNullOrDifferentType(obj))
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return Id == entity.Id;
    }

    public static bool operator ==(Entity? entity, Entity? other)
    {

        return entity is not null && other is not null && entity.Equals(other);
    }

    public static bool operator !=(Entity? entity, Entity? other)
    {
        return !(entity == other);
    }

    private bool IsNullOrDifferentType([NotNullWhen(false)] object? obj)
    {
        return obj is null || typeof(object) != GetType();
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}