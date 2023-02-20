using Microsoft.EntityFrameworkCore;
using SocialApp.Application.Common.Repositories.ReadRepositories;
using SocialApp.Application.Common.Repositories.WriteRepositories;
using SocialApp.Application.Common.Services;
using SocialApp.Application.Dtos.Posts;
using SocialApp.Application.Features.Posts.Commands.CreatePostCommand;
using SocialApp.Application.Features.Posts.Queries.GetPostsByProfileIdQuery;
using SocialApp.Domain.Posts;
using System.Collections.Generic;

namespace SocialApp.Persistence.Services;
public sealed class PostService : IPostService {
    private readonly IPostWriteRepository _postWriteRepository;
    private readonly IPostReadRepository _postReadRepository;

    public PostService(IPostWriteRepository postWriteRepository,
                       IPostReadRepository postReadRepository) {
        _postWriteRepository = postWriteRepository;
        _postReadRepository = postReadRepository;
    }

    public async Task CreateAsync(CreatePostCommandRequest createPostCommandRequest, CancellationToken cancellationToken) {
        Post post = new(createPostCommandRequest.ProfileId, createPostCommandRequest.Content);
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