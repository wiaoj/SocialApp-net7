using SocialApp.Application.Common.Persistence.Repositories.ReadRepositories;
using SocialApp.Application.Common.Persistence.Repositories.WriteRepositories;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Dtos.Profiles;
using SocialApp.Application.Features.Profiles.Commands.FollowProfileCommand;
using SocialApp.Application.Features.Profiles.Commands.UnfollowProfileCommand;
using SocialApp.Application.Features.Profiles.Notifications.CreateProfileNotification;
using SocialApp.Application.Features.Profiles.Queries.GetFollowersByProfileIdQuery;
using SocialApp.Domain.Profile;
using SocialApp.Domain.Profile.ValueObjects;
using SocialApp.Domain.User.ValueObjects;

namespace SocialApp.Persistence.Services;
public sealed class ProfileService : IProfileService {
    private readonly IProfileWriteRepository _profileWriteRepository;
    private readonly IProfileReadRepository _profileReadRepository;

    public ProfileService(IProfileWriteRepository profileWriteRepository, IProfileReadRepository profileReadRepository) {
        _profileWriteRepository = profileWriteRepository;
        _profileReadRepository = profileReadRepository;
    }

    public async Task Create(CreateProfileNotificationRequest createProfileNotificationRequest, CancellationToken cancellationToken) {
        //Profile1 profile = Profile1.Create(UserId.Create(createProfileNotificationRequest.UserId));
        Profile profile = new(UserId.Create(createProfileNotificationRequest.UserId));
        await _profileWriteRepository.AddAsync(profile, cancellationToken);
        await _profileWriteRepository.SaveChangesAsync(cancellationToken);
    }

    public Task Delete(CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public async Task FollowProfile(FollowProfileCommandRequest followProfileCommandRequest, CancellationToken cancellationToken) {
        Profile profile = await _profileReadRepository.GetByIdAsync(/*ProfileId.Create*/(followProfileCommandRequest.ProfileId), cancellationToken)
             ?? throw new Exception("Profile not found");

        Profile follower = await _profileReadRepository.GetByIdAsync(/*ProfileId.Create*/(followProfileCommandRequest.FollowerId), cancellationToken)
            ?? throw new Exception("Follower not found");
        //profile.Followers.Add(follower);
        profile.AddFollower(follower);

        //profile.AddFollower(follower);
        List<Profile> updatedProfiles = new() { profile, follower };
        await _profileWriteRepository.UpdateRangeAsync(updatedProfiles, cancellationToken);
        await _profileWriteRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetFollowersByProfileIdResponse> GetById(GetFollowersByProfileIdRequest getFollowersByProfileIdRequest, CancellationToken cancellationToken) {
        Profile profile = await _profileReadRepository.GetByIdWithFollowersAndFollows(getFollowersByProfileIdRequest.ProfileId, cancellationToken)
            ?? throw new Exception("Profile not found");

        ProfileDto profileDto = new(profile.Id,
                                    profile.Follower,
                                    profile.Follow,
                                    profile.Followers?.Select(follower =>
                                        new ProfileFollowersDto(follower.Id)).ToList(),
                                    profile.Follows?.Select(follow =>
                                        new ProfileFollowsDto(follow.Id)).ToList());
        return new(profileDto);
    }

    public async Task UnfollowProfile(UnfollowProfileCommandRequest unfollowProfileCommandRequest, CancellationToken cancellationToken) {
        Profile? profile = await _profileReadRepository.GetByIdWithFollowers(/*ProfileId.Create*/(unfollowProfileCommandRequest.ProfileId), cancellationToken)
             ?? throw new Exception("Profile not found");

        Profile follower = await _profileReadRepository.GetByIdWithFollowers(/*ProfileId.Create*/(unfollowProfileCommandRequest.FollowerId), cancellationToken)
            ?? throw new Exception("Follower not found");

        //profile.Followers.Remove(follower);
        profile.RemoveFollower(follower);

        //profile.RemoveFollower(follower);
        List<Profile> updatedProfiles = new() { profile, follower };
        await _profileWriteRepository.UpdateRangeAsync(updatedProfiles, cancellationToken);
        await _profileWriteRepository.SaveChangesAsync(cancellationToken);
    }

    public Task Update(CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
