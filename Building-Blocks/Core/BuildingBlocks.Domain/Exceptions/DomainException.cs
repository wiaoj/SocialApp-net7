namespace BuildingBlocks.Domain.Exceptions;
public class DomainException : Exception {
    public DomainException(String message) : base(message) { }
}