using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TwitterAPI.Contracts;
using TwitterAPI.Models.DTO;


namespace TwitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserRespository _userRespository;
   
        public UserController(IUserRespository userRepository) 
        { 
            _userRespository = userRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDto>>> Get()
        {
            var usersDto = await _userRespository.Get();     

            return Ok(usersDto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDto>> GetById(Guid id)
        {

            var user = await _userRespository.GetById(id);

            return Ok(user);
        }


        [HttpPost]        
        public async Task<IActionResult> Add([FromBody] UserPostDto user)
        {

            var newUser = new UserPostDto(user.Name, user.UserName, user.Email, user.DateOfBirth, user.Password, user.ProfilePicture, user.ProfileCover, user.ProfileDescription);
                 
            await _userRespository.Add(newUser);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserUpdateDto>> Update([FromBody] UserUpdateDto userUpdate, Guid id)
        {
            var userUpdated = await _userRespository.Update(userUpdate, id);

            var userReturn = new UserUpdateDto(userUpdated.Name, userUpdated.UserName, userUpdated.DateOfBirth, userUpdated.Password, userUpdated.ProfilePicture, userUpdated.ProfileCover, userUpdated.ProfileDescription);

            return Ok(userReturn);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userRespository.Delete(id);

            return Ok();
        }

    }
}
