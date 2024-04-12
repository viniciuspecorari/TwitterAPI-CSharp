using TwitterAPI.Models.DTO;
using TwitterAPI.Models.PostDto;

namespace TwitterAPI.Contracts
{
    public interface IPostRepository
    {
       Task<PostGetDto> GetById(Guid id);
       Task<IEnumerable<PostGetDto>> Get();
       Task Add(PostAddDto postDto);
       Task<PostUpdateDto> Update(PostUpdateDto postDto, Guid id);
       Task Delete(Guid id);
    }
}
