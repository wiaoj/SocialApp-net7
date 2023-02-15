using BuildingBlocks.Domain.Models;
using SocialApp.Domain.Profile.ValueObjects;

namespace SocialApp.Domain.Profile;
public sealed class Profile : AggregateRoot<ProfileId> {
    public Follower Follower { get; private set; }
    public Follow Follow { get; private set; }

    private Profile(ProfileId id,
                    Follower follower,
                    Follow follow) : base(id) {
        Follower = follower;
        Follow = follow;
    }

    public static Profile Create() {
        return new(ProfileId.Create(), Follower.Create(), Follow.Create());
    }

    //public static Profile Create(Int64 follower, Int64 follow) {
    //    return new(ProfileId.Create(), Follower.Create(follower), Follow.Create(follow));
    //}

    public static Profile Create(Follower follower, Follow follow) {
        return new(ProfileId.Create(), follower, follow);
    }
}