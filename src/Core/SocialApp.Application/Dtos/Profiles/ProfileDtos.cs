namespace SocialApp.Application.Dtos.Profiles;
public sealed record ProfileDto(Guid Id, Int64 Follower, Int64 Follow, IList<ProfileFollowersDto>? Followers, IList<ProfileFollowsDto>? Follows);
public sealed record ProfileFollowersDto(Guid Id);
public sealed record ProfileFollowsDto(Guid Id);