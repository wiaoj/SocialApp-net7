using BuildingBlocks.Persistence.EntityFrameworkCore.Conventions;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Persistence.EntityFrameworkCore;
public abstract class DatabaseContextBase : DbContext {
    //private IDbContextTransaction? _currentTransaction;
    protected DatabaseContextBase(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        //AddingSoftDeletes(modelBuilder);
        //AddingVersioning(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        configurationBuilder.Conventions.Add(_ => new SnakeCaseConvention());
        base.ConfigureConventions(configurationBuilder);
    }
}