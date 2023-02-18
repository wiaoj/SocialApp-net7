using BuildingBlocks.Application.Repositories;
using SocialApp.Domain.User;
using SocialApp.Domain.User.ValueObjects;

namespace SocialApp.Application.Common.Persistence.Repositories.ReadRepositories;
public interface IUserReadRepository : IAsyncReadRepository<User, UserId> {
    public Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken);
}