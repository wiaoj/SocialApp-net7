using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowersQuery;
public sealed record GetFollowersQueryRequest : IRequestQuery<GetFollowersQueryResponse> {

    private class Handler : RequestQueryHandler<GetFollowersQueryRequest, GetFollowersQueryResponse> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task<GetFollowersQueryResponse> HandleQueryAsync(GetFollowersQueryRequest query, CancellationToken cancellationToken) {
            return await _profileService.GetFollowers(query, cancellationToken);
        }
    }
}