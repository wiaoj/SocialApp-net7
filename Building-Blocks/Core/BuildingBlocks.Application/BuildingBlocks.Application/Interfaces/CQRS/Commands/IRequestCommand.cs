using MediatR;

namespace BuildingBlocks.Application.Interfaces.CQRS.Commands;
public interface IRequestCommand<out TypeResponse> : IRequest<TypeResponse> where TypeResponse : notnull { }
public interface IRequestCommand : IRequestCommand<Unit> { }
