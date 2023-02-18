using BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
using SocialApp.Application.Common.Persistence.Repositories.WriteRepositories;
using SocialApp.Domain.User;
using SocialApp.Domain.User.ValueObjects;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.Services.Repositories.WriteRepositories;
public sealed class UserWriteRepository : WriteRepository<User, UserId, SocialAppDbContext>, IUserWriteRepository {
    public UserWriteRepository(SocialAppDbContext context) : base(context) { }
}