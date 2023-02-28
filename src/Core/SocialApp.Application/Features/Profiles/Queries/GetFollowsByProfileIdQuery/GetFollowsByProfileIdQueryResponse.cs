using SocialApp.Application.Dtos.Profiles;

namespace SocialApp.Application.Features.Profiles.Queries.GetFollowsByProfileIdQuery;
public sealed record GetFollowsByProfileIdQueryResponse(IList<ProfileFollowsDto> Follows);