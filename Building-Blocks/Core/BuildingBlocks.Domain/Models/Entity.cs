namespace BuildingBlocks.Domain.Models;
public class Entity {
    public DateTime CreatedDate { get; private set; }
    public DateTime? UpdatedDate { get; private set; }
    public void SetCreatedDate() {
        CreatedDate = DateTime.UtcNow;
    }

    public void SetUpdatedDate() {
        UpdatedDate = DateTime.UtcNow;
    }
}
public abstract class Entity<TId> : Entity, IEquatable<Entity<TId>> where TId : notnull {
    public TId Id { get; protected set; }
    protected Entity(TId id) {
        Id = id;
    }

    public sealed override Boolean Equals(Object? @object) {
        return @object is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public Boolean Equals(Entity<TId>? other) {
        return Equals((Object?)other);
    }

    public static Boolean operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
    public static Boolean operator !=(Entity<TId> left, Entity<TId> right) => Equals(left, right) is false;
    public sealed override Int32 GetHashCode() {
        return Id.GetHashCode();
    }

    public sealed override String ToString() {
        ArgumentNullException.ThrowIfNull(nameof(Id));
        return $"{Id}";
    }
}