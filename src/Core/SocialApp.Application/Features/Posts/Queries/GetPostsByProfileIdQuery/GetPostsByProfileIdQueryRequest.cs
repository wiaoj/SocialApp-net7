using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Posts.Queries.GetPostsByProfileIdQuery;
public sealed record GetPostsByProfileIdQueryRequest : IRequestQuery<GetPostsByProfileIdQueryResponse> {
    public required Guid ProfileId { get; set; }

    private class Handler : RequestQueryHandler<GetPostsByProfileIdQueryRequest, GetPostsByProfileIdQueryResponse> {
        private readonly IPostService _postService;

        public Handler(IPostService postService) {
            _postService = postService;
        }

        protected override async Task<GetPostsByProfileIdQueryResponse> HandleQueryAsync(GetPostsByProfileIdQueryRequest query, CancellationToken cancellationToken) {
            return await _postService.GetPostByProfileId(query, cancellationToken);
        }
    }
}