using System.ComponentModel.DataAnnotations;
using TwitterAPI.Models.Entities;

namespace TwitterAPI.Models.DTO
{
    public record UserUpdateDto(string? Name, string? UserName, DateTime? DateOfBirth, string? Password, string? ProfilePicture = null, string? ProfileCover = null , string? ProfileDescription = null)
    {
        public static implicit operator UserUpdateDto(User entity)
        {
            return new UserUpdateDto(entity.Name, entity.UserName, entity.DateOfBirth, entity.Password, entity.ProfilePicture, entity.ProfileCover, entity.ProfileDescription);
        }
    }
}
