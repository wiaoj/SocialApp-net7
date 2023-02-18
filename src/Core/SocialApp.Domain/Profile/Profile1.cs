using BuildingBlocks.Domain.Models;
using SocialApp.Domain.Profile.ValueObjects;
using SocialApp.Domain.User.ValueObjects;

namespace SocialApp.Domain.Profile;
public sealed class Profile1 : AggregateRoot<ProfileId> {
    public UserId UserId { get; private set; }
    public User.User User { get; set; }
    public Follower Follower { get; private set; }
    public Follow Follow { get; private set; }

    private readonly List<Profile1> _followers = new();
    public IReadOnlyCollection<Profile1> Followers => _followers.AsReadOnly();

    //private readonly List<Profile> _follows = new();
    //public IReadOnlyCollection<Profile> Follows => _follows.AsReadOnly();

    private Profile1(UserId userId,
                    ProfileId id,
                    Follower follower,
                    Follow follow) : base(id) {
        UserId = userId;
        Follower = follower;
        Follow = follow;
    }

    public static Profile1 Create(UserId userId) {
        return new(userId, ProfileId.Create(), Follower.Create(), Follow.Create());
    }

    public static Profile1 Create(UserId userId, Follower follower, Follow follow) {
        return new(userId, ProfileId.Create(), follower, follow);
    }

    public Profile1 AddFollower(Profile1 profile) {
        if(_followers.Any(x => x.Equals(profile))) 
            return this;
        
        _followers.Add(profile);
        Follower.Increase();
        profile.Follow.Increase();
        return this;
    }

    public Profile1 RemoveFollower(Profile1 profile) {
        if(_followers.Any(x => x.Equals(profile)) is false)
            return this;

        _followers.Remove(profile);
        Follower.Decrease();
        profile.Follow.Decrease();
        return this;
    }

    //public Profile AddFollow(Profile profile) {
    //    if(_follows.Any(x => x.Equals(profile)))
    //        return this;

    //    _follows.Add(profile);
    //    Follow.Increase();
    //    profile.Follow.Increase();
    //    return this;
    //}

    //public Profile RemoveFollow(Profile profile) {
    //    if(_follows.Any(x => x.Equals(profile)) is false)
    //        return this;

    //    _follows.Remove(profile);
    //    Follow.Decrease();
    //    profile.Follow.Decrease();
    //    return this;
    //}
}