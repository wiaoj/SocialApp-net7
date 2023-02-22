using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowersByProfileIdQuery;
public sealed record GetByProfileIdQueryRequest : IRequestQuery<GetByProfileIdQueryResponse> {
    public required Guid ProfileId { get; set; }

    private class Handler : RequestQueryHandler<GetByProfileIdQueryRequest, GetByProfileIdQueryResponse> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task<GetByProfileIdQueryResponse> HandleQueryAsync(GetByProfileIdQueryRequest query, CancellationToken cancellationToken) {
            GetByProfileIdQueryResponse response = await _profileService.GetById(query, cancellationToken);
            return response;
        }
    }
}