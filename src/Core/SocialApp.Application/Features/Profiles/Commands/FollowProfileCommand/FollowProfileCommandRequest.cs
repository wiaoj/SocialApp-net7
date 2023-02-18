using BuildingBlocks.Application.CQRS.Commands;
using BuildingBlocks.Application.Interfaces.CQRS.Commands;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Commands.FollowProfileCommand;
public sealed record FollowProfileCommandRequest : IRequestCommand {
    public required Guid ProfileId { get; set; }
    public required Guid FollowerId { get; set; }

    private sealed class Handler : RequestCommandHandler<FollowProfileCommandRequest> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task HandleCommandAsync(FollowProfileCommandRequest command, CancellationToken cancellationToken) {
            await _profileService.FollowProfile(command, cancellationToken);
        }
    }
}