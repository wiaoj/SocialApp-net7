using BuildingBlocks.Domain.Models;
using SocialApp.Domain.Posts;
using SocialApp.Domain.Profile.ValueObjects;
using SocialApp.Domain.User.ValueObjects;

namespace SocialApp.Domain.Profile;
public sealed class Profile : AggregateRoot<Guid> {
    public UserId UserId { get; private set; }
    public User.User User { get; private set; }
    public Int64 Follower { get; private set; }
    public Int64 Follow { get; private set; }
    private readonly IList<Profile> _followers = new List<Profile>();
    public IReadOnlyCollection<Profile> Followers => _followers.AsReadOnly();
    private readonly IList<Profile> _follows = new List<Profile>();
    public IReadOnlyCollection<Profile> Follows => _follows.AsReadOnly();

    private readonly IList<Post> _posts = new List<Post>();
    public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();
    //public Profile(UserId userId) : base(ProfileId.Create()) {
    //    UserId = userId;
    //}

    public Profile(UserId userId) : base(Guid.NewGuid()) {
        UserId = userId;
    }

    public Profile AddFollower(Profile profile) {
        if(_followers.Any(x => x.Equals(profile)))
            return this;

        _followers.Add(profile);
        Follower++;

        profile._follows.Add(this);
        profile.Follow++;
        //profile.AddFollow(this);
        return this;
    }

    public Profile RemoveFollower(Profile profile) {
        if(_followers.Any(x => x.Equals(profile)) is false)
            return this;

        _followers.Remove(profile);
        Follower--;

        profile._follows.Remove(this);
        profile.Follow--;
        //profile.RemoveFollow(this);
        return this;
    }

    //private Profile AddFollow(Profile profile) {
    //    if(_follows.Any(x => x.Equals(profile)))
    //        return this;

    //    _follows.Add(profile);
    //    Follow++;
    //    return this;
    //}

    //private Profile RemoveFollow(Profile profile) {
    //    if(_follows.Any(x => x.Equals(profile)) is false)
    //        return this;

    //    _follows.Remove(profile);
    //    Follow--;
    //    return this;
    //}

    public Profile AddPost(Post post) {
        return this;
    }
}