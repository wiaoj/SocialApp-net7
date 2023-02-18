using System.Linq.Expressions;

namespace BuildingBlocks.Application.Repositories;

public interface IAsyncReadRepository<TypeEntity, TypeEntityId> : IRepository<TypeEntity>
    where TypeEntity : class
    where TypeEntityId : notnull {
    public Int64 Count { get; }
    public Task<IQueryable<TypeEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<IQueryable<TypeEntity>> GetAllAsync(Boolean tracking, CancellationToken cancellationToken);

    public Task<IQueryable<TypeEntity>> FindAsync(Expression<Func<TypeEntity, Boolean>> expression, CancellationToken cancellationToken);
    public Task<IQueryable<TypeEntity>> FindAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean tracking, CancellationToken cancellationToken);

    public Task<TypeEntity?> FindOneAsync(Expression<Func<TypeEntity, Boolean>> expression, CancellationToken cancellationToken);
    public Task<TypeEntity?> FindOneAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean tracking, CancellationToken cancellationToken);

    public Task<TypeEntity?> GetByIdAsync(TypeEntityId id, CancellationToken cancellationToken);
    public Task<TypeEntity?> GetByIdAsync(TypeEntityId id, Boolean tracking, CancellationToken cancellationToken);
}