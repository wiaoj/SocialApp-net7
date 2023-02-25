using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Queries.GetProfileByUserIdQuery;
public sealed record GetProfileQueryRequest : IRequestQuery<GetProfileQueryResponse> {
    //public required Guid UserId { get; set; }

    private class Handler : RequestQueryHandler<GetProfileQueryRequest, GetProfileQueryResponse> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task<GetProfileQueryResponse> HandleQueryAsync(GetProfileQueryRequest query, CancellationToken cancellationToken) {
            return await _profileService.GetProfile(query, cancellationToken);
        }
    }
}