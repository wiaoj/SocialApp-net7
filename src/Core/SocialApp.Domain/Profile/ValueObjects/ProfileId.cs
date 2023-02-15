using BuildingBlocks.Domain.Models;

namespace SocialApp.Domain.Profile.ValueObjects;
public sealed class ProfileId : ValueObject {
    public Guid Value { get; set; }

    private ProfileId(Guid value) {
        Value = value;
    }

    public static ProfileId Create() {
        return new(Guid.NewGuid());
    }

    public static ProfileId Create(Guid value) {
        return new(value);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}