namespace BuildingBlocks.Abstractions.Repositories;

public interface IAsyncWriteRepository<TypeEntity, TypeEntityId> : IRepository<TypeEntity>, IAsyncUnitOfWork
    where TypeEntity : class
    where TypeEntityId : notnull {
    public Task AddAsync(TypeEntity entity, CancellationToken cancellationToken);
    public Task AddRangeAsync(IEnumerable<TypeEntity> entities, CancellationToken cancellationToken);

    public Task UpdateAsync(TypeEntity entity, CancellationToken cancellationToken);
    public Task UpdateRangeAsync(IEnumerable<TypeEntity> entities, CancellationToken cancellationToken);

    public Task DeleteAsync(TypeEntityId entityId, CancellationToken cancellationToken);
    public Task DeleteAsync(TypeEntity entity, CancellationToken cancellationToken);
    public Task DeleteRangeAsync(IEnumerable<TypeEntity> entities, CancellationToken cancellationToken);
}