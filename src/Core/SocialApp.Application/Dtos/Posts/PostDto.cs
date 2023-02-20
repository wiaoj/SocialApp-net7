namespace SocialApp.Application.Dtos.Posts;
public sealed record PostDto(Guid Id, Guid ProfileId, String Content);