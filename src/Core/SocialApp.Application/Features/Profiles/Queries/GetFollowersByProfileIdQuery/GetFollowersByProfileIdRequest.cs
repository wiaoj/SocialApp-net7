using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowersByProfileIdQuery;
public sealed record GetFollowersByProfileIdRequest : IRequestQuery<GetFollowersByProfileIdResponse> {
    public required Guid ProfileId { get; set; }

    private class Handler : RequestQueryHandler<GetFollowersByProfileIdRequest, GetFollowersByProfileIdResponse> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task<GetFollowersByProfileIdResponse> HandleQueryAsync(GetFollowersByProfileIdRequest query, CancellationToken cancellationToken) {
            GetFollowersByProfileIdResponse response = await _profileService.GetById(query, cancellationToken);
            return response;
        }
    }
}