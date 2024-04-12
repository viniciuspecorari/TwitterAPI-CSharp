using System.Globalization;

namespace TwitterAPI.Models.PostDto
{
    public record PostGetDto (Guid UserId, string UserName, string Description, string? MediaUrl, DateTime DateCreated, int QtdLikes, int QtdComments)
    {

        public static implicit operator PostGetDto(GetPost entity)
        {
            return new PostGetDto(entity.UserId, entity.UserName, entity.Description, entity.MediaUrl, entity.DateCreated, entity.QtdLikes, entity.QtdComments);
        }
    }
}
