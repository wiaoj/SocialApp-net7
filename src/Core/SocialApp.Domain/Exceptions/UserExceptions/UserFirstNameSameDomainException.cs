using BuildingBlocks.Domain.Exceptions;

namespace SocialApp.Domain.Exceptions.UserExceptions;

public sealed class UserFirstNameSameDomainException : DomainException {
    public UserFirstNameSameDomainException() : base("İsminiz zaten aynı") { }
    public UserFirstNameSameDomainException(string message) : base(message) { }
}