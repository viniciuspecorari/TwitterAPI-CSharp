using System.ComponentModel.DataAnnotations;

namespace TwitterAPI.Models.DTO
{
    public record UserPostDto(string Name, string UserName, string Email, DateTime DateOfBirth, string Password, string? Role, string? ProfilePicture = null, string? ProfileCover = null , string? ProfileDescription = null)
    {
        public static implicit operator UserPostDto(User entity)
        {
            return new UserPostDto(entity.Name, entity.UserName, entity.Email, entity.DateOfBirth, entity.Password, entity.Role, entity.ProfilePicture, entity.ProfileCover, entity.ProfileDescription);
        }
    }
}
