using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowsQuery;
public sealed record GetFollowsQueryRequest : IRequestQuery<GetFollowsQueryResponse> {

    private class Handler : RequestQueryHandler<GetFollowsQueryRequest, GetFollowsQueryResponse> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task<GetFollowsQueryResponse> HandleQueryAsync(GetFollowsQueryRequest query, CancellationToken cancellationToken) {
            return await _profileService.GetFollows(query, cancellationToken);
        }
    }
}