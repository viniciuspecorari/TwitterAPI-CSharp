using System.ComponentModel.DataAnnotations;


namespace TwitterAPI.Models.DTO
{
    public record UserLoginGetDto (string Email, string Password)
    {        
        public static implicit operator UserLoginGetDto(User  entity)
        {
            return new UserLoginGetDto(entity.Email, entity.Password);
        }
    }
}
