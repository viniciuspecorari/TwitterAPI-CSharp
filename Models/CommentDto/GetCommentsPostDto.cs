namespace TwitterAPI.Models
{
    public record GetCommentsPostDto(string Description, DateTime CreatedAt, Guid UserId, string UserName, string UserPicture, Guid PostId)
    {
        public static implicit operator GetCommentsPostDto(GetCommentsPost entity)
        {                                                               
            return new GetCommentsPostDto(entity.Description, entity.CreatedAt, entity.UserId, entity.UserName, entity.UserPicture, entity.PostId);
        }
    }
}
