using Microsoft.EntityFrameworkCore.ChangeTracking;
using TwitterAPI.Contracts;
using TwitterAPI.Data;
using TwitterAPI.Models.DTO;
using TwitterAPI.Models.Entities;

namespace TwitterAPI.Repository
{
    public class UserRepository : IUserRespository
    {
        private readonly TwitterContext _context;

        public UserRepository(TwitterContext context)
        {
            _context = context;    
        }

        public async Task<bool> AddUser(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                UserName = userDto.UserName,
                Email = userDto.Email,
                DateOfBirth = userDto.DateOfBirth,
                Password = userDto.Password,
                ProfilePicture = userDto.ProfilePicture,
                ProfileCover = userDto.ProfileCover,
                ProfileDescription = userDto.ProfileDescription,
                RegisterDateTime = DateTime.Now

            };

            _context.Users.Add(user);            
            var result = await _context.SaveChangesAsync() > 0 ;

            return result;
        }
    }
}
