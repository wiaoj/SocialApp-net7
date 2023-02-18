using BuildingBlocks.Domain.Models;
using SocialApp.Domain.User.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace SocialApp.Domain.User;
public sealed class User : AggregateRoot<UserId> {
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public PasswordSalt PasswordSalt { get; private set; }
    public PasswordHash PasswordHash { get; private set; }

    private User(UserId id,
                 FirstName firstName,
                 LastName lastName,
                 Email email,
                 PasswordSalt passwordSalt,
                 PasswordHash passwordHash) : base(id) {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
    }

    public static User Create(FirstName firstName, LastName lastName, Email email, PasswordSalt passwordSalt, PasswordHash passwordHash) {
        return new(UserId.Create(), firstName, lastName, email, passwordSalt, passwordHash);
    }

    public static User Create(String firstName, String lastName, String email, String password) {
        (PasswordSalt passwordSalt, PasswordHash passwordHash) = CreatePassword(password);
        return Create(FirstName.Create(firstName),
                      LastName.Create(lastName),
                      Email.Create(email),
                      passwordSalt,
                      passwordHash);
    }

    public static (PasswordSalt, PasswordHash) CreatePassword(String password) {
        using HMACSHA512 hmac = new();

        Byte[] passwordSalt = hmac.Key;
        Byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return (PasswordSalt.Create(passwordSalt), PasswordHash.Create(passwordHash));
    }

    public void VerifyPassword(String loginPassword) {
        using HMACSHA512 hmac = new(PasswordSalt.Value);

        Byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginPassword));

        if(computedHash.SequenceEqual(PasswordHash.Value) is false) {
            throw new Exception("Şifreniz yanlış");
        }
    }
}