using BuildingBlocks.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
public class WriteRepository<TypeEntity, TypeEntityId, DatabaseContext> : Repository<TypeEntity, DatabaseContext>, IAsyncWriteRepository<TypeEntity, TypeEntityId>
    where TypeEntity : class
    where TypeEntityId : notnull
    where DatabaseContext : DbContext {
    protected WriteRepository(DatabaseContext context) : base(context) { }

    public async Task AddAsync(TypeEntity entity, CancellationToken cancellationToken) {
        await Table.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    public async Task AddRangeAsync(IEnumerable<TypeEntity> entities, CancellationToken cancellationToken) {
        await Table.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(TypeEntityId entityId, CancellationToken cancellationToken) {
        TypeEntity? entity = await Table.FindAsync(entityId, cancellationToken).ConfigureAwait(false)
            ?? throw new Exception($"Entity not found id: {entityId}");

        await DeleteAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(TypeEntity entity, CancellationToken cancellationToken) {
        await Task.Run(() => Table.Remove(entity), cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<TypeEntity> entities, CancellationToken cancellationToken) {
        await Task.Run(() => Table.RemoveRange(entities), cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken) {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TypeEntity entity, CancellationToken cancellationToken) {
        await Task.Run(() => Table.Update(entity), cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<TypeEntity> entities, CancellationToken cancellationToken) {
        await Task.Run(() => Table.UpdateRange(entities), cancellationToken);
    }
}