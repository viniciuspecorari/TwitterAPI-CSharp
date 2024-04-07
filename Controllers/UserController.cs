using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("Dados inválidos");
            }

            var newUser = new UserDto
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Password = user.Password,
                ProfilePicture = user.ProfilePicture,
                ProfileCover = user.ProfileCover,
                ProfileDescription = user.ProfileDescription,
            };
                
            var result = await _userRespository.AddUser(newUser);

            return result ? Ok() : BadRequest();
        }

    }
}
