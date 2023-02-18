using BuildingBlocks.Domain.Models;

namespace SocialApp.Domain.Profile.ValueObjects;

public sealed class Follow : ValueObject {
    public Int64 Value { get; private set; }

    private Follow(Int64 value) {
        Value = value;
    }

    public static Follow Create() {
        return new(0);
    }

    public static Follow Create(Int64 value) {
        return new(value);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }

    internal Follow Increase() {
        Value++;
        return this;
    }
    internal Follow Decrease() {
        Value--;
        return this;
    }
}