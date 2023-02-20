using BuildingBlocks.Application.CQRS.Notifications;
using BuildingBlocks.Application.Interfaces.CQRS.Notifications;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Profiles.Notifications.CreateProfileNotification;
public sealed record CreateProfileNotificationRequest : INotification {
    public required Guid UserId { get; set; }
    //public required String ProfileName { get; set; }

    private sealed class Handler : NotificationHandler<CreateProfileNotificationRequest> {
        private readonly IProfileService _profileService;

        public Handler(IProfileService profileService) {
            _profileService = profileService;
        }

        protected override async Task HandleNotificationAsync(CreateProfileNotificationRequest notification, CancellationToken cancellationToken) {
            await _profileService.Create(notification, cancellationToken);
        }
    }
}