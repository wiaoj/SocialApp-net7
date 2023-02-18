﻿using BuildingBlocks.Application.Repositories;
using SocialApp.Domain.User;
using SocialApp.Domain.User.ValueObjects;

namespace SocialApp.Application.Common.Persistence.Repositories.WriteRepositories;

public interface IUserWriteRepository : IAsyncWriteRepository<User, UserId> { }