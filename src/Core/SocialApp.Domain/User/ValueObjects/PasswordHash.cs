using BuildingBlocks.Domain.Models;

namespace SocialApp.Domain.User.ValueObjects;
public sealed class PasswordHash : ValueObject {
    public Byte[] Value { get; private set; }

    private PasswordHash(Byte[] value) {
        Value = value;
    }

    public static PasswordHash Create(Byte[] value) {
        return new(value);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}