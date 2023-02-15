using BuildingBlocks.Domain.Exceptions;

namespace SocialApp.Domain.Exceptions.UserExceptions;

public sealed class UserLastNameSameDomainException : DomainException
{
    public UserLastNameSameDomainException() : base("Soyisminiz zaten aynı") { }
    public UserLastNameSameDomainException(string message) : base(message) { }
}