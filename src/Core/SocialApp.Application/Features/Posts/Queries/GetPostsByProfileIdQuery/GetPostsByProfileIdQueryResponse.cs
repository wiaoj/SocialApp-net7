using SocialApp.Application.Dtos.Posts;

namespace SocialApp.Application.Features.Posts.Queries.GetPostsByProfileIdQuery;
public sealed record GetPostsByProfileIdQueryResponse(IList<PostDto> Posts);