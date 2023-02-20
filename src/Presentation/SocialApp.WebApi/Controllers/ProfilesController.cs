using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Application.Features.Profiles.Commands.FollowProfileCommand;
using SocialApp.Application.Features.Profiles.Commands.UnfollowProfileCommand;
using SocialApp.Application.Features.Profiles.Queries.GetFollowersByProfileIdQuery;

namespace SocialApp.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProfilesController : ControllerBase {
    private readonly ISender _sender;

    public ProfilesController(ISender sender) {
        _sender = sender;
    }

    //[Route("[action]")]
    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateProfileNotificationRequest request, CancellationToken cancellationToken) {
    //    await _sender.Send(request, cancellationToken);
    //    return Created("","");
    //}

    [HttpPost]
    [Route("[action]/{request.ProfileId}/{request.FollowerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> FollowProfile([FromBody] FollowProfileCommandRequest request, CancellationToken cancellationToken) {
        await _sender.Send(request, cancellationToken);
        return Ok();
    }

    [HttpPost]
    [Route("[action]/{request.ProfileId}/{request.FollowerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UnfollowProfile([FromBody] UnfollowProfileCommandRequest request, CancellationToken cancellationToken) {
        await _sender.Send(request, cancellationToken);
        return Ok();
    }

    [HttpGet]
    [Route("[action]/{request.ProfileId}")]
    [ProducesResponseType(typeof(GetFollowersByProfileIdQueryResponse),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFollowersByProfileId([FromRoute] GetFollowersByProfileIdQueryRequest request, CancellationToken cancellationToken) {
        GetFollowersByProfileIdQueryResponse response = await _sender.Send(request, cancellationToken);
        return Ok(response);
    }
}