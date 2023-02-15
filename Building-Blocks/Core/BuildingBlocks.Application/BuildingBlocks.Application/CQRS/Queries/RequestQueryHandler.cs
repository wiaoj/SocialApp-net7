using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries.Handler;
using MediatR;

namespace BuildingBlocks.Application.CQRS.Queries;
public abstract class RequestQueryHandler<TypeQuery> : IRequestQueryHandler<TypeQuery>
    where TypeQuery : IRequestQuery {
    protected abstract Task HandleQueryAsync(TypeQuery query, CancellationToken cancellationToken);
    public async Task<Unit> Handle(TypeQuery command, CancellationToken cancellationToken) {
        await HandleQueryAsync(command, cancellationToken);
        return Unit.Value;
    }
}

public abstract class RequestQueryHandler<TypeQuery, TypeResponse> : IRequestQueryHandler<TypeQuery, TypeResponse>
    where TypeQuery : IRequestQuery<TypeResponse>
    where TypeResponse : notnull {
    protected abstract Task<TypeResponse> HandleQueryAsync(TypeQuery query, CancellationToken cancellationToken);
    public async Task<TypeResponse> Handle(TypeQuery request, CancellationToken cancellationToken) {
        return await HandleQueryAsync(request, cancellationToken);
    }
}