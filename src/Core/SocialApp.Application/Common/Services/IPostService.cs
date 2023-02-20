using SocialApp.Application.Dtos.Posts;
using SocialApp.Application.Features.Posts.Commands.CreatePostCommand;
using SocialApp.Application.Features.Posts.Queries.GetPostsByProfileIdQuery;

namespace SocialApp.Application.Common.Services;
public interface IPostService {
    public Task CreateAsync(CreatePostCommandRequest createPostCommandRequest, CancellationToken cancellationToken);
    public Task<GetPostsByProfileIdQueryResponse> GetPostByProfileId(GetPostsByProfileIdQueryRequest getPostsByProfileIdQueryRequest, CancellationToken cancellationToken);
}