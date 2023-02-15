using MediatR;

namespace BuildingBlocks.Application.Interfaces.CQRS.Queries;
public interface IRequestQuery<out TypeResponse> : IRequest<TypeResponse> where TypeResponse : notnull { }
public interface IRequestQuery : IRequestQuery<Unit> { }
