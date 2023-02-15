using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using MediatR;

namespace BuildingBlocks.Application.Interfaces.CQRS.Queries.Handler;
public interface IRequestQueryHandler<in TypeQuery, TypeResponse> : IRequestHandler<TypeQuery, TypeResponse>
    where TypeQuery : IRequestQuery<TypeResponse>
    where TypeResponse : notnull { }
public interface IRequestQueryHandler<in TypeQuery> : IRequestQueryHandler<TypeQuery, Unit>
    where TypeQuery : IRequestQuery<Unit> { }