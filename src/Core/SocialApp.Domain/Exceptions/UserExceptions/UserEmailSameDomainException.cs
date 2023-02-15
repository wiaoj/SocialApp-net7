using BuildingBlocks.Domain.Exceptions;

namespace SocialApp.Domain.Exceptions.UserExceptions;

public sealed class UserEmailSameDomainException : DomainException
{
    public UserEmailSameDomainException() : base("Emailiniz zaten aynı") { }
    public UserEmailSameDomainException(string message) : base(message) { }
}