using BuildingBlocks.Domain.Models;
using SocialApp.Domain.Exceptions.UserExceptions;
using SocialApp.Domain.User.ValueObjects;

namespace SocialApp.Domain.User;
public sealed class User : AggregateRoot<UserId> {
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }

    private User(UserId id, Name name, Email email, Password password) : base(id) {
        Name = name;
        Email = email;
        Password = password;
    }

    public static User Create(Name name, Email email, Password password) {
        return new(UserId.Create(), name, email, password);
    }

    public static User Create(String firstName, String lastName, String email, String password) {
        return Create(Name.Create(firstName, lastName), Email.Create(email), Password.Create(password));
    }

    public User UpdateName(String firstName, String lastName) {

        if(Name.FirstName.Equals(firstName))
            throw new UserFirstNameSameDomainException();

        if(Name.LastName.Equals(lastName))
            throw new UserLastNameSameDomainException();

        Name = Name.Create(firstName, lastName);

        return this;
    }

    public User UpdateEmail(String email) {
        if(Email.Value.Equals(email))
            throw new UserEmailSameDomainException();

        Email = Email.Create(email);
        return this;
    }

    public User UpdatePassword(String value) {
        Password password = Password.Create(value);

        if(Password.Equals(password))
            throw new UserPasswordSameDomainException();

        Password = password;
        return this;
    }
}