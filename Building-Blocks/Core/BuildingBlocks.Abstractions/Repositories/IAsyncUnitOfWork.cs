namespace BuildingBlocks.Abstractions.Repositories;

public interface IAsyncUnitOfWork {
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}