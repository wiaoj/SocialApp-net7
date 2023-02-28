using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Features.Profiles.Queries.GetFollowersByProfileIdQuery;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowsByProfileIdQuery;
public sealed record GetFollowsByProfileIdQueryRequest : IRequestQuery<GetFollowsByProfileIdQueryResponse> {
    public required Guid ProfileId { get; set; }

    private class Handler : RequestQueryHandler<GetFollowsByProfileIdQueryRequest, GetFollowsByProfileIdQueryResponse> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task<GetFollowsByProfileIdQueryResponse> HandleQueryAsync(GetFollowsByProfileIdQueryRequest query, CancellationToken cancellationToken) {
            return await _profileService.GetFollowsByProfileId(query, cancellationToken);
        }
    }
}