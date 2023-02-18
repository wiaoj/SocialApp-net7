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

    [Route("[action]/{request.ProfileId}/{request.FollowerId}")]
    [HttpPut]
    public async Task<IActionResult> FollowProfile([FromRoute] FollowProfileCommandRequest request, CancellationToken cancellationToken) {
        await _sender.Send(request, cancellationToken);
        return Ok();
    }

    [Route("[action]/{request.ProfileId}/{request.FollowerId}")]
    [HttpPut]
    public async Task<IActionResult> UnfollowProfile([FromRoute] UnfollowProfileCommandRequest request, CancellationToken cancellationToken) {
        await _sender.Send(request, cancellationToken);
        return Ok();
    }

    [Route("[action]/{request.ProfileId}")]
    [HttpGet]
    public async Task<IActionResult> GetFollowersByProfileId([FromRoute] GetFollowersByProfileIdRequest request, CancellationToken cancellationToken) {
        GetFollowersByProfileIdResponse response = await _sender.Send(request, cancellationToken);
        return Ok(response.Profile);
    }
}