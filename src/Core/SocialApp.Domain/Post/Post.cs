using BuildingBlocks.Domain.Models;

namespace SocialApp.Domain.Posts;
public sealed class Post : AggregateRoot<Guid> {
    public Guid ProfileId { get; private set; }
    public Profile.Profile Profile { get; private set; }
    public String Content { get; private set; }

    public Post(Guid profileId, String content) : base(Guid.NewGuid()) {
        ProfileId = profileId;
        Content = content;
    }
}