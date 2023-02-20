using BuildingBlocks.Persistence.EntityFrameworkCore.Repositories;
using SocialApp.Application.Common.Repositories.WriteRepositories;
using SocialApp.Domain.Posts;
using SocialApp.Persistence.Context;

namespace SocialApp.Persistence.Services.Repositories.WriteRepositories;
public sealed class PostWriteRepository : WriteRepository<Post, Guid, SocialAppDbContext>, IPostWriteRepository {
    public PostWriteRepository(SocialAppDbContext context) : base(context) { }
}