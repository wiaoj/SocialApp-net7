using BuildingBlocks.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
public abstract class Repository<TypeEntity, DatabaseContext> : IRepository<TypeEntity>
    where TypeEntity : class
    where DatabaseContext : DbContext {

    private protected readonly DatabaseContext _context;
    protected Repository(DatabaseContext context) {
        _context = context;
    }

    public DbSet<TypeEntity> Table => _context.Set<TypeEntity>();
}