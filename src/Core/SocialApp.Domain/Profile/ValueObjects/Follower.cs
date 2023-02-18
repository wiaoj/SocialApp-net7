using BuildingBlocks.Domain.Models;

namespace SocialApp.Domain.Profile.ValueObjects;
public sealed class Follower : ValueObject {
    public Int64 Value { get; private set; }

    private Follower(Int64 value) {
        Value = value;
    }

    public static Follower Create() {
        return new(0);
    }

    public static Follower Create(Int64 value) {
        return new(value);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }

    internal Follower Increase() {
        Value++;
        return this;
    }
    internal Follower Decrease() {
        Value--;
        return this;
    }
}