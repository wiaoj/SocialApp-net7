using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Application.Features.Users.Commands.RegisterCommand;
using SocialApp.Application.Features.Users.Queries.LoginQuery;

namespace SocialApp.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationsController : ControllerBase {
    private readonly ISender _sender;

    public AuthenticationsController(ISender sender) {
        _sender = sender;
    }

    protected String? IpAddress =>
        Request.Headers.ContainsKey("X-Forwarded-For")
        ? Request.Headers["X-Forwarded-For"]
        : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();


    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(typeof(RegisterCommandResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterCommandRequest request, CancellationToken cancellationToken) {
        RegisterCommandResponse response = await _sender.Send(request, cancellationToken);
        return Created("", response);
    }

    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(typeof(LoginQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginQueryRequest request, CancellationToken cancellationToken) {
        LoginQueryResponse response = await _sender.Send(request, cancellationToken);
        return Ok(response);
    }
}