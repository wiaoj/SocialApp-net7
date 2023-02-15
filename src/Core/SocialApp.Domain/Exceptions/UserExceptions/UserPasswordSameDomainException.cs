using BuildingBlocks.Domain.Exceptions;

namespace SocialApp.Domain.Exceptions.UserExceptions;

public sealed class UserPasswordSameDomainException : DomainException
{
    public UserPasswordSameDomainException() : base("Şifreniz aynı olamaz") { }
    public UserPasswordSameDomainException(string message) : base(message) { }
}