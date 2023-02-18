using SocialApp.Application.Features.Users.Dtos;
using SocialApp.Domain.User;

namespace SocialApp.Application.Common.Authentication;
public interface IJwtTokenGenerator {
    public AccessToken GenerateToken(User user);
}