using TwitterAPI.Contracts;
using TwitterAPI.Data;
using TwitterAPI.Models;

namespace TwitterAPI.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TwitterContext _context;

        public CommentRepository(TwitterContext context)
        {
            _context = context;
        }


        public async Task AddComment(AddCommentDto commentDto)
        {
            var newComment = new Comment
            {
                Description = commentDto.Description,
                CreatedAt = DateTime.Now,
                UserId = commentDto.UserId,
                PostId = commentDto.PostId,
            };

            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetCommentsPostDto>> GetComments(Guid postId)
        {
           var commentsInPost = from comment in _context.Comments
                                 where comment.PostId == postId
                                 join post in _context.Posts on comment.PostId equals post.Id
                                 join user in _context.Users on comment.UserId equals user.Id                                 
                                 select new GetCommentsPostDto(

                                       comment.Description
                                     , comment.CreatedAt
                                     , comment.UserId
                                     , user.UserName
                                     , user.ProfilePicture
                                     , comment.PostId                                                                          
                                     );
            

            return commentsInPost.ToList();
        }

    }
}
