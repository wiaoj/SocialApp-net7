using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace SocialApp.Domain.User.ValueObjects;

public sealed class Email : ValueObject {
    public String Value { get; private set; }

    private Email(String value) {
        Value = value;
    }

    public static Email Create(String email) {
        return new(email);
    }
    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }

    //public static implicit operator Email(String email) => new(email);
    //public static implicit operator String(Email email) => email.Value;
}