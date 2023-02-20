using BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
using SocialApp.Application.Common.Repositories.ReadRepositories;
using SocialApp.Domain.Posts;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.Services.Repositories.ReadRepositories;
public sealed class PostReadRepository : ReadRepository<Post, Guid, SocialAppDbContext>, IPostReadRepository {
    public PostReadRepository(SocialAppDbContext context) : base(context) { }
}