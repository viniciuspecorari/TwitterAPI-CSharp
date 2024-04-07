using System.ComponentModel.DataAnnotations;

namespace TwitterAPI.Models.DTO
{
    public class UserDto
    {        
        public required string Name { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Password { get; set; }
        public string? ProfilePicture { get; set; }
        public string? ProfileCover { get; set; }

        [MaxLength(280)]
        public string? ProfileDescription { get; set; }        
    }
}
