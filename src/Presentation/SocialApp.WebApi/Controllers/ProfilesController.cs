using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Application.Features.Profiles.Commands.FollowProfileCommand;
using SocialApp.Application.Features.Profiles.Commands.UnfollowProfileCommand;
using SocialApp.Application.Features.Profiles.Queries.GetByProfileIdQuery;
using SocialApp.Application.Features.Profiles.Queries.GetProfileByUserIdQuery;

namespace SocialApp.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProfilesController : ControllerBase {
    private readonly ISender _sender;
    private readonly IHttpContextAccessor _contextAccessor;
    public ProfilesController(ISender sender, IHttpContextAccessor contextAccessor) {
        _sender = sender;
        _contextAccessor = contextAccessor;
    }

    //[Route("[action]")]
    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateProfileNotificationRequest request, CancellationToken cancellationToken) {
    //    await _sender.Send(request, cancellationToken);
    //    return Created("","");
    //}

    [HttpPost]
    [Route("[action]/{request.ProfileId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> FollowProfile([FromBody] FollowProfileCommandRequest request, CancellationToken cancellationToken) {
        await _sender.Send(request, cancellationToken);
        return Ok();
    }

    [HttpPost]
    [Route("[action]/{request.ProfileId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UnfollowProfile([FromBody] UnfollowProfileCommandRequest request, CancellationToken cancellationToken) {
        await _sender.Send(request, cancellationToken);
        return Ok();
    }

    [HttpGet]
    [Route("[action]/{request.ProfileId}")]
    [ProducesResponseType(typeof(GetByProfileIdQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByProfileId([FromRoute] GetByProfileIdQueryRequest request, CancellationToken cancellationToken) {
        GetByProfileIdQueryResponse response = await _sender.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    [Route("[action]")]
    [ProducesResponseType(typeof(GetProfileQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfile(CancellationToken cancellationToken) {
        GetProfileQueryResponse response = await _sender.Send(new GetProfileQueryRequest(), cancellationToken);
        return Ok(response);
    }
}