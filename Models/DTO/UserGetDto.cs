using System.ComponentModel.DataAnnotations;
using TwitterAPI.Models.Entities;


namespace TwitterAPI.Models.DTO
{
    public record UserGetDto (Guid id, string Name, string UserName, string Email, DateTime DateOfBirth, string ProfilePicture, string ProfileCover , string ProfileDescription, DateTime RegisterDateTime)
    {        
        public static implicit operator UserGetDto(User  entity)
        {
            return new UserGetDto(entity.Id, entity.Name, entity.UserName, entity.Email, entity.DateOfBirth, entity.ProfilePicture, entity.ProfileCover, entity.ProfileDescription, entity.RegisterDateTime);
        }
    }
}
