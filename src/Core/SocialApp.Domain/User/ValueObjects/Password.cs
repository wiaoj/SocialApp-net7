using BuildingBlocks.Core.Abstractions.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace SocialApp.Domain.User.ValueObjects;

public sealed class Password : ValueObject {
    public Byte[] Salt { get; private set; }
    public Byte[] Hash { get; private set; }

    private Password(Byte[] salt, Byte[] hash) {
        Salt = salt;
        Hash = hash;
    }

    public static Password Create(Byte[] salt, Byte[] hash) {
        return new(salt, hash);
    }

    public static Password Create(String password) {
        using HMACSHA512 hmac = new();

        Byte[] passwordSalt = hmac.Key;
        Byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return new(passwordSalt, passwordHash);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Salt;
        yield return Hash;
    }
}