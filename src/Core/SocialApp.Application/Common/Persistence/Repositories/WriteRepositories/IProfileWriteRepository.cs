using BuildingBlocks.Application.Repositories;
using SocialApp.Domain.Profile;
using SocialApp.Domain.Profile.ValueObjects;

namespace SocialApp.Application.Common.Persistence.Repositories.WriteRepositories;
public interface IProfileWriteRepository : IAsyncWriteRepository<Profile, Guid> { }