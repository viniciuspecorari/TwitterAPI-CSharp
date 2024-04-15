namespace TwitterAPI.Models.LikeDto
{
    public record LikeDto(Guid UserId, Guid PostId)
    {
        public static implicit operator LikeDto(Like entity)
        {
            return new LikeDto(entity.UserId, entity.PostId);
        }
    }
}
