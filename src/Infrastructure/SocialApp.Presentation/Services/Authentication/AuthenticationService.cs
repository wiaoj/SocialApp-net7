using SocialApp.Application.Common.Authentication;
using SocialApp.Application.Common.Persistence.Repositories.ReadRepositories;
using SocialApp.Application.Common.Persistence.Repositories.WriteRepositories;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Features.Users.Commands.RegisterCommand;
using SocialApp.Application.Features.Users.Dtos;
using SocialApp.Application.Features.Users.Queries.LoginQuery;
using SocialApp.Domain.User;
using SocialApp.Domain.User.ValueObjects;

namespace SocialApp.Persistence.Services.Authentication;
public sealed class AuthenticationService : IAuthenticationService {
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository) {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<(AccessToken, User)> RegisterAsync(RegisterCommandRequest registerCommandRequest, CancellationToken cancellationToken) {
        if(await _userReadRepository.GetUserByEmailAsync(Email.Create(registerCommandRequest.Email), cancellationToken) is not null) {
            throw new Exception("User with given email already exists.");
        }

        User user = User.Create(registerCommandRequest.FirstName,
                                registerCommandRequest.LastName,
                                registerCommandRequest.Email,
                                registerCommandRequest.Password);
        await _userWriteRepository.AddAsync(user, cancellationToken);
        await _userWriteRepository.SaveChangesAsync(cancellationToken);

        return (_jwtTokenGenerator.GenerateToken(user), user);
    }

    public async Task<AccessToken> LoginAsync(LoginQueryRequest loginQueryRequest, CancellationToken cancellationToken) {
        if(await _userReadRepository.GetUserByEmailAsync(Email.Create(loginQueryRequest.Email), cancellationToken) is not User user) {
            throw new Exception("User with given email does not exists.");
        }

        user.VerifyPassword(loginQueryRequest.Password);

        return _jwtTokenGenerator.GenerateToken(user);
    }
}