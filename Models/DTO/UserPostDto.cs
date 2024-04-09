using System.ComponentModel.DataAnnotations;
using TwitterAPI.Models.Entities;

namespace TwitterAPI.Models.DTO
{
    public record UserPostDto(string Name, string UserName, string Email, DateTime DateOfBirth, string Password, string? ProfilePicture = null, string? ProfileCover = null , string? ProfileDescription = null)
    {
        public static implicit operator UserPostDto(User entity)
        {
            return new UserPostDto(entity.Name, entity.UserName, entity.Email, entity.DateOfBirth, entity.Password, entity.ProfilePicture, entity.ProfileCover, entity.ProfileDescription);
        }
    }
}
