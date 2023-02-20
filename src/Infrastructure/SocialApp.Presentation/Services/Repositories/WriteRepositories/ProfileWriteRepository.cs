using BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
using SocialApp.Application.Common.Repositories.WriteRepositories;
using SocialApp.Domain.Profile;
using SocialApp.Domain.Profile.ValueObjects;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.Services.Repositories.WriteRepositories;
public sealed class ProfileWriteRepository : WriteRepository<Profile, Guid, SocialAppDbContext>, IProfileWriteRepository {
    public ProfileWriteRepository(SocialAppDbContext context) : base(context) { }
}