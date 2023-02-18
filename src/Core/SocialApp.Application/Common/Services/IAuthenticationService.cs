using SocialApp.Application.Features.Users.Commands.RegisterCommand;
using SocialApp.Application.Features.Users.Dtos;
using SocialApp.Application.Features.Users.Queries.LoginQuery;
using SocialApp.Domain.User;

namespace SocialApp.Application.Common.Services;
public interface IAuthenticationService {
    Task<(AccessToken, User)> RegisterAsync(RegisterCommandRequest registerCommandRequest, CancellationToken cancellationToken);
    Task<AccessToken> LoginAsync(LoginQueryRequest loginQueryRequest, CancellationToken cancellationToken);
}