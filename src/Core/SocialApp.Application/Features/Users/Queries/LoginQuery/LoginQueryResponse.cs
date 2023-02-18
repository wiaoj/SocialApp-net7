using SocialApp.Application.Features.Users.Dtos;

namespace SocialApp.Application.Features.Users.Queries.LoginQuery;
public sealed record LoginQueryResponse(AccessToken Token);