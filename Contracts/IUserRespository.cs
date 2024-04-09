using System.Collections.Generic;
using TwitterAPI.Models.DTO;


namespace TwitterAPI.Contracts
{
    public interface IUserRespository
    {     
        
        Task<UserGetDto> GetById(Guid id);
        Task<IEnumerable<UserGetDto>> Get();
        Task Add(UserPostDto user);
        Task Delete(Guid id);
        Task<UserUpdateDto> Update(UserUpdateDto user, Guid id);
    }
}
