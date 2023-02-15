using BuildingBlocks.Domain.Models;

namespace SocialApp.Domain.User.ValueObjects;
public sealed class UserId : ValueObject {
    //private UserId generate;

    public Guid Value { get; private set; }
    private UserId(Guid value) {
        Value = value;
    }

    public static UserId Create() {
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid value) {
        return new(value);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }

    //public static implicit operator UserId(Guid id) => new(id);
    //public static implicit operator Guid(UserId id) => id.Value;
}