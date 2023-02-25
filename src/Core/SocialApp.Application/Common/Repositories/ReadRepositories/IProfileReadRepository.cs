using BuildingBlocks.Application.Repositories;
using SocialApp.Domain.Profile;

namespace SocialApp.Application.Common.Repositories.ReadRepositories;

public interface IProfileReadRepository : IAsyncReadRepository<Profile, Guid>
{
    public Task<Profile?> GetByIdWithFollowers(Guid id, CancellationToken cancellationToken);
    public Task<Profile?> GetByIdWithFollowersAndFollows(Guid id, CancellationToken cancellationToken);
    public Task<Profile?> GetProfileByUserId(Guid userId, CancellationToken cancellationToken);
}