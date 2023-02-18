using BuildingBlocks.Domain.Models;
using BuildingBlocks.Persistence.MsSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialApp.Domain.Profile;
using SocialApp.Domain.User;
using System.Reflection;

namespace SocialApp.Persistence.Context;
public sealed class SocialAppDbContext : MsSQLDatabaseContext {
    public const String DEFAULT_SCHEMA = "socialApp";
    public SocialAppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    //public DbSet<Profile1> Profiles { get; set; }

    public override async Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default) {

        IEnumerable<EntityEntry<Entity>> datas = ChangeTracker.Entries<Entity>();
        foreach(EntityEntry<Entity> data in datas) {
            switch(data.State) {
                case EntityState.Added:
                    data.Entity.SetCreatedDate();
                    break;
                case EntityState.Modified:
                    data.Entity.SetUpdatedDate();
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}