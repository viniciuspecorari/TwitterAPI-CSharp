namespace TwitterAPI.Models
{
    public record AddCommentDto(string Description, Guid UserId, Guid PostId)
    {
        public static implicit operator AddCommentDto(Comment entity)
        {                                                               
            return new AddCommentDto(entity.Description, entity.UserId, entity.PostId);
        }
    }
}
