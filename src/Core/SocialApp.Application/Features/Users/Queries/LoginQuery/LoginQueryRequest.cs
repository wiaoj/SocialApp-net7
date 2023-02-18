using BuildingBlocks.Application.CQRS.Queries;
using BuildingBlocks.Application.Interfaces.CQRS.Queries;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Features.Users.Dtos;

namespace SocialApp.Application.Features.Users.Queries.LoginQuery;
public sealed record LoginQueryRequest : IRequestQuery<LoginQueryResponse> {
    public required String Email { get; set; }
    public required String Password { get; set; }

    private sealed class Handler : RequestQueryHandler<LoginQueryRequest, LoginQueryResponse> {
        private readonly IAuthenticationService _authenticationService;

        public Handler(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }

        protected override async Task<LoginQueryResponse> HandleQueryAsync(LoginQueryRequest query, CancellationToken cancellationToken) {
            AccessToken token = await _authenticationService.LoginAsync(query, cancellationToken);
            return new(token);
        }
    }
}