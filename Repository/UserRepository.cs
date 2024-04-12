using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using TwitterAPI.Contracts;
using TwitterAPI.Data;
using TwitterAPI.Errors;
using TwitterAPI.Models.DTO;
using TwitterAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TwitterAPI.Repository
{
    public class UserRepository : IUserRespository
    {
        private readonly TwitterContext _context;

        public UserRepository(TwitterContext context)
        {
            _context = context;    
        }


        public async Task<IEnumerable<UserGetDto>> Get()
        {
            var users = await _context.Users.ToListAsync();

            var usersDto = users.Select(user => new UserGetDto(

                  user.Id
                , user.Name
                , user.UserName
                , user.Email
                , user.DateOfBirth
                , user.Password
                , user.Role
                , user.ProfilePicture
                , user.ProfileCover
                , user.ProfileDescription
                , user.RegisterDateTime
                )).ToList();


            return usersDto;
        }


        public async Task<UserGetDto> GetById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is null)
            {
                throw new Exceptions(StatusCodes.Status404NotFound.ToString(), "User invalid", id.ToString());
            }

            var userDto = new UserGetDto(
                 
                  user.Id
                , user.Name
                , user.UserName
                , user.Email
                , user.DateOfBirth
                , user.Password
                , user.Role
                , user.ProfilePicture
                , user.ProfileCover
                , user.ProfileDescription
                , user.RegisterDateTime);

            return userDto;
        }

        public async Task<UserGetDto> GetByEmail(string email)
        {
            var user = await _context.Users
                   .Where(u => u.Email == email) // Substitua "usuario@exemplo.com" pelo e-mail desejado
                   .FirstOrDefaultAsync();

            if (user is null)
            {
                throw new Exceptions(StatusCodes.Status404NotFound.ToString(), "User invalid", email.ToString());
            }

            var userDto = new UserGetDto(

                  user.Id
                , user.Name
                , user.UserName
                , user.Email                
                , user.DateOfBirth
                , user.Password
                , user.Role
                , user.ProfilePicture
                , user.ProfileCover
                , user.ProfileDescription
                , user.RegisterDateTime);

            return userDto;
        }



        public async Task Add(UserPostDto user)
        {
            var newUser = new User
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Password = user.Password,
                Role = user.Role,
                ProfilePicture = user.ProfilePicture,
                ProfileCover = user.ProfileCover,
                ProfileDescription = user.ProfileDescription,
                RegisterDateTime = DateTime.Now

            };

            _context.Users.Add(newUser);            
            await _context.SaveChangesAsync();            
        }

        public async Task Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();            
        }

        public async Task<UserUpdateDto> Update(UserUpdateDto userUpdate, Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            user.Name = userUpdate.Name ?? user.Name;
            user.UserName = userUpdate.UserName ?? user.UserName;
            user.DateOfBirth = userUpdate.DateOfBirth ?? user.DateOfBirth;
            user.Password = userUpdate.Password ?? user.Password;
            user.ProfilePicture = userUpdate.ProfilePicture ?? user.ProfilePicture;
            user.ProfileCover = userUpdate.ProfileCover ?? user.ProfileCover;
            user.ProfileDescription = userUpdate.ProfileDescription ?? user.ProfileDescription;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
