namespace TwitterAPI.Models.FollowerDto
{
    public record GetFollowersDto(Guid UserId, string UserName)
    {
        public static implicit operator GetFollowersDto(User entity)
        {
            return new GetFollowersDto(entity.Id, entity.UserName);
        }
    }
}
