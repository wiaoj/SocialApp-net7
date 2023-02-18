﻿using BuildingBlocks.Application.Repositories;
using SocialApp.Domain.Profile;
using SocialApp.Domain.Profile.ValueObjects;

namespace SocialApp.Application.Common.Persistence.Repositories.ReadRepositories;

public interface IProfileReadRepository : IAsyncReadRepository<Profile, Guid> {
    public Task<Profile?> GetByIdWithFollowers(Guid id, CancellationToken cancellationToken);
    public Task<Profile?> GetByIdWithFollowersAndFollows(Guid id, CancellationToken cancellationToken);
}