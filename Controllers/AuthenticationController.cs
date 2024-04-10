using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterAPI.Contracts;
using TwitterAPI.Models.DTO;

namespace TwitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IToken _token;

        public AuthenticationController(IToken token)
        {
            _token = token;
        }

        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(UserLoginGetDto userLogin)
        {            
            var token = await _token.GenerateToken(userLogin);

            if (token is null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
