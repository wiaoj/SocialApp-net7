using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuildingBlocks.Persistence.EntityFrameworkCore.Interceptors;
// Ref: https://www.meziantou.net/entity-framework-core-soft-delete-using-query-filters.htm
public class SoftDeleteInterceptor : SaveChangesInterceptor {
    public override ValueTask<InterceptionResult<Int32>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<Int32> result,
        CancellationToken cancellationToken = default) {

        if(eventData.Context is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        IEnumerable<EntityEntry> entries = eventData.Context.ChangeTracker.Entries();
        foreach(EntityEntry entry in entries) {
            switch(entry.State) {
                case EntityState.Added:
                    //if(entry.Entity is IEntityHaveSoftDelete)
                    entry.CurrentValues[EntityFrameworkCoreConstants.SOFT_DELETE_PROPERTY_NAME] = false;
                    break;
                case EntityState.Deleted:
                    //if(entry.Entity is IEntityHaveSoftDelete) {
                    entry.State = EntityState.Modified;
                    eventData.Context.Entry(entry.Entity).CurrentValues[EntityFrameworkCoreConstants.SOFT_DELETE_PROPERTY_NAME] = true;
                    //}
                    break;
            }

        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}