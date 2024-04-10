using TwitterAPI.Models.DTO;
using TwitterAPI.Models.Entities;

namespace TwitterAPI.Contracts
{
    public interface IToken
    {

        Task<string> GenerateToken(UserLoginGetDto userLogin);

    }
}
