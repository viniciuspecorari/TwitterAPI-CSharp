using System.Globalization;

namespace TwitterAPI.Models.PostDto
{
    public record PostUpdateDto (string? Description, string? MediaUrl)
    {

        public static implicit operator PostUpdateDto(Post entity)
        {
            return new PostUpdateDto(entity.Description, entity.MediaUrl);
        }
    }
}
