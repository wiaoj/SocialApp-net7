using BuildingBlocks.Application.Interfaces.CQRS.Commands;
using BuildingBlocks.Application.Interfaces.CQRS.Commands.Handler;
using MediatR;

namespace BuildingBlocks.Application.CQRS.Commands;
public abstract class RequestCommandHandler<TypeCommand> : IRequestCommandHandler<TypeCommand>
    where TypeCommand : IRequestCommand {
    protected abstract Task HandleCommandAsync(TypeCommand command, CancellationToken cancellationToken);
    public async Task<Unit> Handle(TypeCommand command, CancellationToken cancellationToken) {
        await HandleCommandAsync(command, cancellationToken);
        return Unit.Value;
    }
}

public abstract class RequestCommandHandler<TypeCommand, TypeResponse> : IRequestCommandHandler<TypeCommand, TypeResponse>
    where TypeCommand : IRequestCommand<TypeResponse>
    where TypeResponse : notnull {
    protected abstract Task<TypeResponse> HandleCommandAsync(TypeCommand command, CancellationToken cancellationToken);
    public async Task<TypeResponse> Handle(TypeCommand request, CancellationToken cancellationToken) {
        return await HandleCommandAsync(request, cancellationToken);
    }
}