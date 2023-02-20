using BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialApp.Application.Common.Repositories.ReadRepositories;
using SocialApp.Domain.User;
using SocialApp.Domain.User.ValueObjects;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.Services.Repositories.ReadRepositories;
public sealed class UserReadRepository : ReadRepository<User, UserId, SocialAppDbContext>, IUserReadRepository {
    public UserReadRepository(SocialAppDbContext context) : base(context) { }

    public async Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken) {
        return await Table.SingleOrDefaultAsync(x => x.Email.Equals(email), cancellationToken);
    }
}