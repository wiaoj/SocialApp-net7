using BuildingBlocks.Domain.Models;

namespace SocialApp.Domain.User.ValueObjects;
public sealed class LastName : ValueObject {
    public const Byte VALUE_MAX_LENGTH = 64;
    public String Value { get; private set; }

    private LastName(String value) {
        Value = value;
    }

    public static LastName Create(String value) {
        ArgumentException.ThrowIfNullOrEmpty(value);

        return value.Length > VALUE_MAX_LENGTH
            ? throw new ArgumentException($"Soyisminiz çok uzun, {VALUE_MAX_LENGTH}'den uzun olamaz.")
            : (new(value.Trim()));
    }
    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}