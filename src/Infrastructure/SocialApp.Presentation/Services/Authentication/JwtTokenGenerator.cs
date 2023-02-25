using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialApp.Application.Common.Authentication;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Features.Users.Dtos;
using SocialApp.Domain.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SocialApp.Persistence.Services.Authentication;
public sealed class JwtTokenGenerator : IJwtTokenGenerator {
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions) {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public AccessToken GenerateToken(User user) {
        DateTime tokenExpiration = _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        Claim[] claims = GetClaims(user);

        JwtSecurityToken jwtSecurityToken = CreateJwtSecurityToken(tokenExpiration, signingCredentials, claims);

        return new(
            Token: new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Expiration: tokenExpiration
        );
    }
    private Claim[] GetClaims(User user) {
        return new Claim[] {
            new(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.GivenName, user.FirstName.Value),
            new(JwtRegisteredClaimNames.FamilyName, user.LastName.Value),
            new(JwtRegisteredClaimNames.Name, $"{user.FirstName.Value} {user.LastName.Value}"),
            new(JwtRegisteredClaimNames.Jti, $"{Guid.NewGuid()}-{Guid.NewGuid()}"),
            new(JwtRegisteredClaimNames.Email, user.Email.Value),
            new(JwtRegisteredClaimNames.AuthTime, _dateTimeProvider.UtcNow.ToString())
        };
    }

    private JwtSecurityToken CreateJwtSecurityToken(
        DateTime tokenExpiration,
        SigningCredentials signingCredentials,
        Claim[] claims) {
        return new(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            notBefore: _dateTimeProvider.UtcNow,
            expires: tokenExpiration,
            signingCredentials: signingCredentials);
    }

    private String GenerateRandomRefreshToken() {
        Byte[] numberByte = new Byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(numberByte);
        return Convert.ToBase64String(numberByte);
    }
}