using System.Runtime.CompilerServices;

namespace TwitterAPI.Models.FollowerDto
{
    public record FollowerDto(Guid UserId, Guid UserFollowId)
    {

        public static implicit operator FollowerDto(Follower entity)
        {
            return new FollowerDto(entity.UserId, entity.UserFollowId); 
        }
    }
}
