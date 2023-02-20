using BuildingBlocks.Application.Repositories;
using SocialApp.Domain.Posts;

namespace SocialApp.Application.Common.Repositories.ReadRepositories;
public interface IPostReadRepository : IAsyncReadRepository<Post, Guid> { }