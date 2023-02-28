using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowersByProfileIdQuery;
public sealed record GetFollowersByProfileIdQueryRequest : IRequestQuery<GetFollowersByProfileIdQueryResponse> {
    public required Guid ProfileId { get; set; }

    private class Handler : RequestQueryHandler<GetFollowersByProfileIdQueryRequest, GetFollowersByProfileIdQueryResponse> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task<GetFollowersByProfileIdQueryResponse> HandleQueryAsync(GetFollowersByProfileIdQueryRequest query, CancellationToken cancellationToken) {
            return await _profileService.GetFollowersByProfileId(query, cancellationToken);
        }
    }
}