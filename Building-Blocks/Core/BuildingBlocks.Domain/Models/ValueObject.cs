namespace BuildingBlocks.Domain.Models;

public abstract class ValueObject : IEquatable<ValueObject> {
    public abstract IEnumerable<Object> GetEqualityComponents();

    public sealed override Boolean Equals(Object? @object) {
        if(@object is null || @object.GetType().Equals(GetType()))
            return false;
        ValueObject valueObject = (ValueObject)@object;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static Boolean operator ==(ValueObject left, ValueObject right) => Equals(left, right);
    public static Boolean operator !=(ValueObject left, ValueObject right) => Equals(left, right) is false;
    public sealed override Int32 GetHashCode() {
        return GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
    }

    public Boolean Equals(ValueObject? other) {
        return Equals((Object?)other);
    }

    public sealed override String? ToString() {
        return base.ToString();
    }
}