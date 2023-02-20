using BuildingBlocks.Application.CQRS.Commands;
using BuildingBlocks.Application.Interfaces.CQRS.Commands;
using SocialApp.Application.Common.Services;

namespace SocialApp.Application.Features.Posts.Commands.CreatePostCommand;
public sealed record CreatePostCommandRequest : IRequestCommand
{
    public required Guid ProfileId { get; set; }
    public required string Content { get; set; }

    private sealed class Handler : RequestCommandHandler<CreatePostCommandRequest>
    {
        private readonly IPostService _postService;

        public Handler(IPostService postService)
        {
            _postService = postService;
        }

        protected override async Task HandleCommandAsync(CreatePostCommandRequest command, CancellationToken cancellationToken)
        {
            await _postService.CreateAsync(command, cancellationToken);
        }
    }
}