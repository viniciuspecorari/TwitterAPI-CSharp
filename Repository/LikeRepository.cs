using TwitterAPI.Contracts;
using TwitterAPI.Data;
using TwitterAPI.Models;
using TwitterAPI.Models.LikeDto;

namespace TwitterAPI.Repository
{
    public class LikeRepository : ILikeRepository
    {

        private readonly TwitterContext _context;

        public LikeRepository(TwitterContext context)
        {
            _context = context;
        }

        public async Task AddLike(LikeDto likeDto)
        {
            var like = new Like
            {
                CreatedAt = DateTime.Now,
                UserId = likeDto.UserId,
                PostId = likeDto.PostId
            };

            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveLike(LikeDto likeDto)
        {
            var likeId = (from l in _context.Likes
                        where l.UserId == likeDto.UserId && l.PostId == likeDto.PostId
                        select l.Id).FirstOrDefault();

            var like = await _context.Likes.FindAsync(likeId);

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }
    }
}
