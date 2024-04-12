using System.Globalization;

namespace TwitterAPI.Models.PostDto
{
    public record PostAddDto (string Description, string? MediaUrl,  Guid UserId)
    {

        public static implicit operator PostAddDto(Post entity)
        {
            return new PostAddDto(entity.Description, entity.MediaUrl,  entity.UserId);
        }
    }
}
