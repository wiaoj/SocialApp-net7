using BuildingBlocks.Core.Abstractions.Domain.Models;
using System.Reflection.Metadata;

namespace SocialApp.Domain.User.ValueObjects;

public sealed class Name : ValueObject {
    public const Byte FIRST_NAME_MAX_LENGTH = 64;
    public const Byte LAST_NAME_MAX_LENGTH = 64;

    public String FirstName { get; private set; }
    public String LastName { get; private set; }

    private Name(String firstName, String lastName) {
        (FirstName, LastName) = (firstName, lastName);
    }

    public static Name Create(String firstName, String lastName) {
        if(String.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("İsminiz boş olamaz.");

        if(firstName.Length > FIRST_NAME_MAX_LENGTH)
            throw new ArgumentException($"İsminiz çok uzun, {FIRST_NAME_MAX_LENGTH}'den uzun olamaz.");

        if(String.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Soyisminiz boş olamaz.");

        if(lastName.Length > LAST_NAME_MAX_LENGTH)
            throw new ArgumentException($"Soyisminiz çok uzun, {LAST_NAME_MAX_LENGTH}'den uzun olamaz.");

        return new(firstName, lastName);
    }

    public String FullName => String.Format("{0} {1}", FirstName, LastName);

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return FirstName;
        yield return LastName;
    }
}