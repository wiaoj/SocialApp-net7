using Microsoft.AspNetCore.Http;
using SocialApp.Application.Common.Repositories.ReadRepositories;
using SocialApp.Application.Common.Repositories.WriteRepositories;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Dtos.Profiles;
using SocialApp.Application.Features.Profiles.Commands.FollowProfileCommand;
using SocialApp.Application.Features.Profiles.Commands.UnfollowProfileCommand;
using SocialApp.Application.Features.Profiles.Notifications.CreateProfileNotification;
using SocialApp.Application.Features.Profiles.Queries.GetByProfileIdQuery;
using SocialApp.Application.Features.Profiles.Queries.GetFollowersByProfileIdQuery;
using SocialApp.Application.Features.Profiles.Queries.GetFollowersQuery;
using SocialApp.Application.Features.Profiles.Queries.GetFollowsByProfileIdQuery;
using SocialApp.Application.Features.Profiles.Queries.GetFollowsQuery;
using SocialApp.Application.Features.Profiles.Queries.GetProfileByUserIdQuery;
using SocialApp.Domain.Profile;
using SocialApp.Domain.User.ValueObjects;
using System.Security.Claims;

namespace SocialApp.Persistence.Services;
public sealed class ProfileService : IProfileService {
    private readonly IProfileWriteRepository _profileWriteRepository;
    private readonly IProfileReadRepository _profileReadRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProfileService(IProfileWriteRepository profileWriteRepository,
                          IProfileReadRepository profileReadRepository,
                          IHttpContextAccessor httpContextAccessor) {
        _profileWriteRepository = profileWriteRepository;
        _profileReadRepository = profileReadRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    private Guid GetCurrentUserId {
        get {
            String userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new Exception("Profile not found");

            return Guid.Parse(userId);
        }
    }

    private ProfileDto ConvertProfileToProfileDto(Profile profile) {
        ProfileDto profileDto = new(profile.Id,
                                    profile.Follower,
                                    profile.Follow,
                                    profile.Followers?.Select(ConvertProfileFollowersToProfileFollowersDto).ToList(),
                                    profile.Follows?.Select(ConvertProfileFollowersToProfileFollowsDto).ToList());

        return profileDto;
    }

    private ProfileFollowersDto ConvertProfileFollowersToProfileFollowersDto(Profile follower) {
        return new(follower.Id);
    }

    private ProfileFollowsDto ConvertProfileFollowersToProfileFollowsDto(Profile follow) {
        return new(follow.Id);
    }

    private static Profile ProfileNotFoundException => 
        throw new Exception("Profile not found");


    public async Task Create(CreateProfileNotificationRequest createProfileNotificationRequest, CancellationToken cancellationToken) {
        
        Profile profile = new(UserId.Create(createProfileNotificationRequest.UserId));
        await _profileWriteRepository.AddAsync(profile, cancellationToken);
        await _profileWriteRepository.SaveChangesAsync(cancellationToken);
    }

    public Task Delete(CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public async Task FollowProfile(FollowProfileCommandRequest followProfileCommandRequest, CancellationToken cancellationToken) {
        Profile profile = await _profileReadRepository.GetByIdAsync(/*ProfileId.Create*/(followProfileCommandRequest.ProfileId), cancellationToken)
             ?? ProfileNotFoundException;

        Profile follower = await _profileReadRepository.GetProfileByUserId(GetCurrentUserId, cancellationToken)
             ?? ProfileNotFoundException;

        profile.AddFollower(follower);

        List<Profile> updatedProfiles = new() { profile, follower };
        await _profileWriteRepository.UpdateRangeAsync(updatedProfiles, cancellationToken);
        await _profileWriteRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetByProfileIdQueryResponse> GetById(GetByProfileIdQueryRequest getByProfileIdRequest, CancellationToken cancellationToken) {
        Profile profile = await _profileReadRepository.GetByIdWithFollowersAndFollows(getByProfileIdRequest.ProfileId, cancellationToken)
            ?? ProfileNotFoundException;

        return new(ConvertProfileToProfileDto(profile));
    }

    public async Task<GetProfileQueryResponse> GetProfile(GetProfileQueryRequest getProfileByUserIdQueryRequest, CancellationToken cancellationToken) {
        Profile profile = await _profileReadRepository.GetProfileByUserId(GetCurrentUserId, cancellationToken)
            ?? ProfileNotFoundException;

        return new(ConvertProfileToProfileDto(profile));
    }

    public async Task UnfollowProfile(UnfollowProfileCommandRequest unfollowProfileCommandRequest, CancellationToken cancellationToken) {
        Profile? profile = await _profileReadRepository.GetByIdWithFollowers(/*ProfileId.Create*/(unfollowProfileCommandRequest.ProfileId), cancellationToken)
             ?? ProfileNotFoundException;

        Profile follower = await _profileReadRepository.GetProfileByUserId(GetCurrentUserId, cancellationToken)
             ?? ProfileNotFoundException;

        profile.RemoveFollower(follower);

        List<Profile> updatedProfiles = new() { profile, follower };
        await _profileWriteRepository.UpdateRangeAsync(updatedProfiles, cancellationToken);
        await _profileWriteRepository.SaveChangesAsync(cancellationToken);
    }

    public Task Update(CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }

    public async Task<GetFollowersQueryResponse> GetFollowers(GetFollowersQueryRequest getFollowersQueryRequest, CancellationToken cancellationToken) {
        Profile? profile = await _profileReadRepository.GetByUserIdWithFollowers(GetCurrentUserId, cancellationToken)
            ?? ProfileNotFoundException;

        List<ProfileFollowersDto> followers = profile.Followers.Select(followers => ConvertProfileFollowersToProfileFollowersDto(followers)).ToList();

        return new(followers);
    }

    public async Task<GetFollowsQueryResponse> GetFollows(GetFollowsQueryRequest getFollowsQueryRequest, CancellationToken cancellationToken) {
        Profile? profile = await _profileReadRepository.GetByUserIdWithFollows(GetCurrentUserId, cancellationToken)
            ?? ProfileNotFoundException;

        List<ProfileFollowsDto> follows = profile.Follows.Select(follows => ConvertProfileFollowersToProfileFollowsDto(follows)).ToList();

        return new(follows);
    }


    public async Task<GetFollowersByProfileIdQueryResponse> GetFollowersByProfileId(GetFollowersByProfileIdQueryRequest getFollowersByProfileIdQueryRequest, CancellationToken cancellationToken) {
        Profile? profile = await _profileReadRepository.GetByIdWithFollowers(getFollowersByProfileIdQueryRequest.ProfileId, cancellationToken)
            ?? ProfileNotFoundException;

        List<ProfileFollowersDto> followers = profile.Followers.Select(followers => ConvertProfileFollowersToProfileFollowersDto(followers)).ToList();

        return new(followers);
    }

    public async Task<GetFollowsByProfileIdQueryResponse> GetFollowsByProfileId(GetFollowsByProfileIdQueryRequest getFollowsByProfileIdQueryRequest, CancellationToken cancellationToken) {
        Profile? profile = await _profileReadRepository.GetByIdWithFollows(getFollowsByProfileIdQueryRequest.ProfileId, cancellationToken)
            ?? ProfileNotFoundException;

        List<ProfileFollowsDto> follows = profile.Follows.Select(follows => ConvertProfileFollowersToProfileFollowsDto(follows)).ToList();

        return new(follows);
    }
}