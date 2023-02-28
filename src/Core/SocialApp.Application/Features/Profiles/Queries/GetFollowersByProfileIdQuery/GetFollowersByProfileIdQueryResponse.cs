using SocialApp.Application.Dtos.Profiles;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowersByProfileIdQuery;
public sealed record GetFollowersByProfileIdQueryResponse(IList<ProfileFollowersDto> Followers);