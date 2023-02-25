using SocialApp.Application.Features.Profiles.Commands.FollowProfileCommand;
using SocialApp.Application.Features.Profiles.Commands.UnfollowProfileCommand;
using SocialApp.Application.Features.Profiles.Notifications.CreateProfileNotification;
using SocialApp.Application.Features.Profiles.Queries.GetByProfileIdQuery;
using SocialApp.Application.Features.Profiles.Queries.GetProfileByUserIdQuery;

namespace SocialApp.Application.Common.Services;
public interface IProfileService {
    public Task Create(CreateProfileNotificationRequest createProfileNotificationRequest, CancellationToken cancellationToken);
    public Task Update(CancellationToken cancellationToken);
    public Task Delete(CancellationToken cancellationToken);

    public Task FollowProfile(FollowProfileCommandRequest followProfileCommandRequest, CancellationToken cancellationToken);
    public Task UnfollowProfile(UnfollowProfileCommandRequest unfollowProfileCommandRequest, CancellationToken cancellationToken);
    public Task<GetByProfileIdQueryResponse> GetById(GetByProfileIdQueryRequest getFollowersByProfileIdRequest, CancellationToken cancellationToken);
    public Task<GetProfileQueryResponse> GetProfile(GetProfileQueryRequest getProfileByUserIdQueryRequest, CancellationToken cancellationToken);
}