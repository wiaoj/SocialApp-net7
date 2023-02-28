using BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialApp.Application.Common.Repositories.ReadRepositories;
using SocialApp.Domain.Profile;
using SocialApp.Domain.Profile.ValueObjects;
using SocialApp.Domain.User;
using SocialApp.Domain.User.ValueObjects;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.Services.Repositories.ReadRepositories;
public sealed class ProfileReadRepository : ReadRepository<Profile, Guid, SocialAppDbContext>, IProfileReadRepository {
    public ProfileReadRepository(SocialAppDbContext context) : base(context) { }

    public async Task<Profile?> GetByIdWithFollowers(Guid id, CancellationToken cancellationToken) {
        Profile? profile = await Table
               .Include(p => p.Followers)
               .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        return profile;
    }

    public async Task<Profile?> GetByIdWithFollows(Guid id, CancellationToken cancellationToken) {
        Profile? profile = await Table
               .Include(p => p.Follows)
               .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        return profile;
    }

    public async Task<Profile?> GetByUserIdWithFollowers(Guid userId, CancellationToken cancellationToken) {
        Profile? profile = await Table
               .Include(p => p.Followers)
               .FirstOrDefaultAsync(x => x.UserId.Equals(UserId.Create(userId)), cancellationToken);
        return profile;
    }

    public async Task<Profile?> GetByUserIdWithFollows(Guid userId, CancellationToken cancellationToken) {
        Profile? profile = await Table
        .Include(p => p.Follows)
               .FirstOrDefaultAsync(x => x.UserId.Equals(UserId.Create(userId)), cancellationToken);
        return profile;
    }

    public async Task<Profile?> GetByIdWithFollowersAndFollows(Guid id, CancellationToken cancellationToken) {
        Profile? profile = await Table
               .Include(p => p.Followers)
               .Include(p => p.Follows)
               .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        return profile;
    }

    public async Task<Profile?> GetProfileByUserId(Guid userId, CancellationToken cancellationToken) {
        Profile? profile = await base.FindOneAsync(x => x.UserId.Equals(UserId.Create(userId)), cancellationToken);
        return profile;
    }
}