namespace BuildingBlocks.Domain.Models;
public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull {
    public TId Id { get; protected set; }
    protected Entity(TId id) => Id = id;

    public sealed override Boolean Equals(Object? @object) => @object is Entity<TId> entity && Id.Equals(entity.Id);
    public Boolean Equals(Entity<TId>? other) => Equals((Object?)other);
    public static Boolean operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
    public static Boolean operator !=(Entity<TId> left, Entity<TId> right) => Equals(left, right) is false;
    public sealed override Int32 GetHashCode() => Id.GetHashCode();
    public sealed override String ToString() {
        ArgumentNullException.ThrowIfNull(nameof(Id));
        return $"{Id}";
    }
}