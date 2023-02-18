using BuildingBlocks.Application.CQRS.Commands;
using BuildingBlocks.Application.Interfaces.CQRS.Commands;
using MediatR;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Features.Profiles.Notifications.CreateProfileNotification;
using SocialApp.Application.Features.Users.Dtos;
using SocialApp.Domain.User;

namespace SocialApp.Application.Features.Users.Commands.RegisterCommand;
public sealed record RegisterCommandRequest : IRequestCommand<RegisterCommandResponse> {
    public required String FirstName { get; set; }
    public required String LastName { get; set; }
    public required String Email { get; set; }
    public required String Password { get; set; }

    private sealed class Handler : RequestCommandHandler<RegisterCommandRequest, RegisterCommandResponse> {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPublisher _publisher;

        public Handler(IAuthenticationService authenticationService, IPublisher publisher) {
            _authenticationService = authenticationService;
            _publisher = publisher;
        }

        protected override async Task<RegisterCommandResponse> HandleCommandAsync(RegisterCommandRequest command, CancellationToken cancellationToken) {
            (AccessToken token, User user) = await _authenticationService.RegisterAsync(command, cancellationToken);
            await _publisher.Publish(new CreateProfileNotificationRequest() { UserId = user.Id.Value }, cancellationToken);
            return new(token);
        }
    }
}