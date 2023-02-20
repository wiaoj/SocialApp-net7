using BuildingBlocks.Application.Repositories;
using SocialApp.Domain.Posts;

namespace SocialApp.Application.Common.Repositories.WriteRepositories;
public interface IPostWriteRepository : IAsyncWriteRepository<Post, Guid> { }