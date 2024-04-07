using TwitterAPI.Models.DTO;


namespace TwitterAPI.Contracts
{
    public interface IUserRespository
    {
        Task<bool> AddUser(UserDto userDto);
    }
}
