using TwitterAPI.Models;
using TwitterAPI.Models.DTO;

namespace TwitterAPI.Contracts
{
    public interface IToken
    {

        Task<string> GenerateToken(UserLoginGetDto userLogin);

    }
}
