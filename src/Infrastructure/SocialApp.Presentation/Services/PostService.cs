using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialApp.Application.Common.Repositories.ReadRepositories;
using SocialApp.Application.Common.Repositories.WriteRepositories;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Dtos.Posts;
using SocialApp.Application.Features.Posts.Commands.CreatePostCommand;
using SocialApp.Application.Features.Posts.Queries.GetPostsByProfileIdQuery;
using SocialApp.Domain.Posts;
using SocialApp.Domain.Profile;
using System.Security.Claims;

namespace SocialApp.Persistence.Services;
public sealed class PostService : IPostService {
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IPostReadRepository _postReadRepository;
    private readonly IProfileReadRepository _profileReadRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PostService(IPostWriteRepository postWriteRepository, IPostReadRepository postReadRepository, IProfileReadRepository profileReadRepository, IHttpContextAccessor httpContextAccessor) {
        _postWriteRepository = postWriteRepository;
        _postReadRepository = postReadRepository;
        _profileReadRepository = profileReadRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    private async Task<Guid> GetCurrentProfileId(CancellationToken cancellationToken) {
        String userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? throw new Exception("Profile not found");

        Profile profile = await _profileReadRepository.GetProfileByUserId(Guid.Parse(userId), cancellationToken)
            ?? throw new Exception("Profile not found");

        return profile.Id;
    }

    public async Task CreateAsync(CreatePostCommandRequest createPostCommandRequest, CancellationToken cancellationToken) {
        Guid profileId = await GetCurrentProfileId(cancellationToken);
        Post post = new(profileId, createPostCommandRequest.Content);
        await _postWriteRepository.AddAsync(post, cancellationToken);
        await _postWriteRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetPostsByProfileIdQueryResponse> GetPostByProfileId(GetPostsByProfileIdQueryRequest getPostsByProfileIdQueryRequest, CancellationToken cancellationToken) {
        IQueryable<Post>? posts = await _postReadRepository.FindAsync(x => x.ProfileId.Equals(getPostsByProfileIdQueryRequest.ProfileId), false, cancellationToken);

        if(posts is null) {
            throw new Exception("Post bulunamadı");
        }

        List<PostDto> postDtos = await posts.Select(x => new PostDto(x.Id, x.ProfileId, x.Content)).ToListAsync(cancellationToken: cancellationToken);
        return new(postDtos);
    }
}