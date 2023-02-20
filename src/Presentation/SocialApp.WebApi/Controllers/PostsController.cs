using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Application.Features.Posts.Commands.CreatePostCommand;
using SocialApp.Application.Features.Posts.Queries.GetPostsByProfileIdQuery;

namespace SocialApp.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase {
    private readonly ISender _sender;

    public PostsController(ISender sender) {
        _sender = sender;
    }

    [HttpPost]
    [Route("[action]/{profileId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromRoute] Guid profileId,
                                            [FromBody] String content,
                                            CancellationToken cancellationToken) {
        await _sender.Send(new CreatePostCommandRequest {
            ProfileId = profileId,
            Content = content
        }, cancellationToken);
        return Created("", new());
    }

    [HttpGet]
    [Route("[action]/{request.ProfileId}")]
    [ProducesResponseType(typeof(GetPostsByProfileIdQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPostsByProfileId([FromRoute] GetPostsByProfileIdQueryRequest request, CancellationToken cancellationToken) {
        GetPostsByProfileIdQueryResponse response = await _sender.Send(request, cancellationToken);
        return Ok(response);
    }
}