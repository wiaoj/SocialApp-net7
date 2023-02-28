using SocialApp.Application.Dtos.Profiles;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowersQuery;
public sealed record GetFollowersQueryResponse(IList<ProfileFollowersDto> Followers);