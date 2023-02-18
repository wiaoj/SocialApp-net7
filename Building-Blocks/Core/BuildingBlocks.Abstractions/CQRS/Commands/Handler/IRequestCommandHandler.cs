using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Commands.Handler;
public interface IRequestCommandHandler<in TypeCommand, TypeResponse> : IRequestHandler<TypeCommand, TypeResponse>
    where TypeCommand : IRequestCommand<TypeResponse>
    where TypeResponse : notnull { }
public interface IRequestCommandHandler<in TypeCommand> : IRequestCommandHandler<TypeCommand, Unit>
    where TypeCommand : IRequestCommand<Unit> { }