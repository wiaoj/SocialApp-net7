using BuildingBlocks.Domain.Models;
using SocialApp.Domain.Exceptions.UserExceptions;

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


    public Email Update(String email) {
        return Value.Equals(email) ? throw new UserEmailSameDomainException() : (new(email));
    }
}