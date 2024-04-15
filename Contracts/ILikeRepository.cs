using TwitterAPI.Models.LikeDto;

namespace TwitterAPI.Contracts
{
    public interface ILikeRepository
    {
        public Task AddLike(LikeDto likeDto);
        public Task RemoveLike(LikeDto likeDto);
    }
}
