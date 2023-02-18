namespace BuildingBlocks.Application.Repositories;

public interface IAsyncUnitOfWork {
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}