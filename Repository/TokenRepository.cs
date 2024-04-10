using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterAPI.Contracts;
using TwitterAPI.Errors;
using TwitterAPI.Models.DTO;
using TwitterAPI.Models.Entities;

namespace TwitterAPI.Repository
{
    public class TokenRepository : IToken
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRespository _userRespository;


        public TokenRepository(IConfiguration configuration, IUserRespository userRespository)
        {
            _configuration = configuration;
            _userRespository = userRespository;
        }


        public async Task<string> GenerateToken(UserLoginGetDto userLogin)
        {
            var userValid = await _userRespository.GetByEmail(userLogin.Email);            

            if (userLogin.Email != userValid.Email || userLogin.Password != userValid.Password)
            {
                throw new Exceptions(StatusCodes.Status404NotFound.ToString(), "User invalid", userLogin.Email.ToString());
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var singinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, userValid.Email),
                    new Claim(type: ClaimTypes.Role, userValid.Role)
                },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: singinCredential
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }

    }
}
