using BuildingBlocks.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
public class ReadRepository<TypeEntity, TypeEntityId, DatabaseContext> : Repository<TypeEntity, DatabaseContext>, IAsyncReadRepository<TypeEntity, TypeEntityId>
    where TypeEntity : class
    where TypeEntityId : notnull
    where DatabaseContext : DbContext {

    protected ReadRepository(DatabaseContext context) : base(context) { }

    public Int64 Count => Table.LongCount();

    private IQueryable<TypeEntity> Quaryable => Table.AsQueryable();

    public async Task<IQueryable<TypeEntity>> FindAsync(Expression<Func<TypeEntity, Boolean>> expression, CancellationToken cancellationToken) {
        return await FindAsync(expression, true, cancellationToken);
    }

    public async Task<IQueryable<TypeEntity>> FindAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean tracking, CancellationToken cancellationToken) {
        IQueryable<TypeEntity> query = Table.Where(expression);
        return await Task.FromResult(tracking ? query : query.AsNoTracking());
    }

    public async Task<TypeEntity?> FindOneAsync(Expression<Func<TypeEntity, Boolean>> expression, CancellationToken cancellationToken) {
        return await FindOneAsync(expression, true, cancellationToken);
    }

    public async Task<TypeEntity?> FindOneAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean tracking, CancellationToken cancellationToken) {
        IQueryable<TypeEntity> query = Quaryable;

        if(tracking is false)
            query = query.AsNoTracking();

        return await query.SingleOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<IQueryable<TypeEntity>> GetAllAsync(CancellationToken cancellationToken) {
        return await GetAllAsync(true, cancellationToken);
    }

    public async Task<IQueryable<TypeEntity>> GetAllAsync(Boolean tracking, CancellationToken cancellationToken) {
        IQueryable<TypeEntity> query = Quaryable;
        return await Task.FromResult(tracking ? query : query.AsNoTracking());
    }

    public async Task<TypeEntity?> GetByIdAsync(TypeEntityId id, CancellationToken cancellationToken) {
        return await GetByIdAsync(id, true, cancellationToken);
    }

    public async Task<TypeEntity?> GetByIdAsync(TypeEntityId id, Boolean tracking, CancellationToken cancellationToken) {
        IQueryable<TypeEntity> query = Quaryable;
        return await Table.FindAsync(id, cancellationToken);
    }
}