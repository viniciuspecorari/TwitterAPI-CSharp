using TwitterAPI.Models;

namespace TwitterAPI.Contracts
{
    public interface ICommentRepository
    {

        public Task AddComment(AddCommentDto commentDto);
        public Task<IEnumerable<GetCommentsPostDto>> GetComments(Guid postId);
    }
}
