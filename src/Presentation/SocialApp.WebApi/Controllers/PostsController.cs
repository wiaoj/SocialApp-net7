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
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreatePostCommandRequest request,
                                            CancellationToken cancellationToken) {
        await _sender.Send(request, cancellationToken);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpGet]
    [Route("[action]/{request.ProfileId}")]
    [ProducesResponseType(typeof(GetPostsByProfileIdQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPostsByProfileId([FromRoute] GetPostsByProfileIdQueryRequest request, CancellationToken cancellationToken) {
        GetPostsByProfileIdQueryResponse response = await _sender.Send(request, cancellationToken);
        return Ok(response);
    }
}