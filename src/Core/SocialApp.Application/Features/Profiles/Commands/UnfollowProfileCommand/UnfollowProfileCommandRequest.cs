using BuildingBlocks.Application.CQRS.Commands;
using BuildingBlocks.Application.Interfaces.CQRS.Commands;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Commands.UnfollowProfileCommand;
public sealed record UnfollowProfileCommandRequest : IRequestCommand {
    public required Guid ProfileId { get; set; }
    //public required Guid FollowerId { get; set; }

    private sealed class Handler : RequestCommandHandler<UnfollowProfileCommandRequest> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task HandleCommandAsync(UnfollowProfileCommandRequest command, CancellationToken cancellationToken) {
            await _profileService.UnfollowProfile(command, cancellationToken);
        }
    }
}