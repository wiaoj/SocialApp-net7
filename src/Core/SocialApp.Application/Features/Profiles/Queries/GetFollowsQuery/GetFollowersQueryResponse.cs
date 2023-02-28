using SocialApp.Application.Dtos.Profiles;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowsQuery;
public sealed record GetFollowsQueryResponse(IList<ProfileFollowsDto> Follows);