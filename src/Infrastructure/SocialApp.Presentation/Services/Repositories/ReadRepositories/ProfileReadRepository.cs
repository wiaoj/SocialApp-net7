using BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialApp.Application.Common.Persistence.Repositories.ReadRepositories;
using SocialApp.Domain.Profile;
using SocialApp.Domain.Profile.ValueObjects;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.Services.Repositories.ReadRepositories;
public sealed class ProfileReadRepository : ReadRepository<Profile, Guid, SocialAppDbContext>, IProfileReadRepository {
    public ProfileReadRepository(SocialAppDbContext context) : base(context) { }

    public async Task<Profile?> GetByIdWithFollowers(Guid id, CancellationToken cancellationToken) {
        var profile = await Table
               .Include(p => p.Followers)
               .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        return profile;
    }

    public async Task<Profile?> GetByIdWithFollowersAndFollows(Guid id, CancellationToken cancellationToken) {
        var profile = await Table
               .Include(p => p.Followers)
               .Include(p => p.Follows)
               .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        return profile;
    }
}