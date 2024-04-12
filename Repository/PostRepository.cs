using Microsoft.EntityFrameworkCore;
using TwitterAPI.Contracts;
using TwitterAPI.Data;
using TwitterAPI.Models;
using TwitterAPI.Models.DTO;
using TwitterAPI.Models.PostDto;

namespace TwitterAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly TwitterContext _context;

        public PostRepository(TwitterContext context)
        {
            _context = context;

        }


        public async Task<IEnumerable<PostGetDto>> Get()
        {
            var postsInfo = from post in _context.Posts
                            join user in _context.Users on post.UserId equals user.Id
                            into userPosts
                            from userPost in userPosts.DefaultIfEmpty()
                            join like in _context.Likes on post.Id equals like.PostId
                            into postLikes
                            from postLike in postLikes.DefaultIfEmpty()
                            join comment in _context.Comments on post.Id equals comment.PostId
                            into postComments
                            from postComment in postComments.DefaultIfEmpty()
                            group new { post, postLike, postComment } by new { userPost.Id, userPost.Name, post.Description, post.MediaUrl, post.DateCreated } into grouped
                            select new PostGetDto
                            (
                                grouped.Key.Id,
                                grouped.Key.Name,
                                grouped.Key.Description,
                                grouped.Key.MediaUrl,
                                grouped.Key.DateCreated,
                                grouped.Count(p => p.postLike != null),
                                grouped.Count(p => p.postComment != null)
                            );
            

            return postsInfo.ToList();
        }

        public async Task<PostGetDto> GetById(Guid Id)
        {
            var postsInfo = from post in _context.Posts
                            where post.Id == Id
                            join user in _context.Users on post.UserId equals user.Id
                            into userPosts
                            from userPost in userPosts.DefaultIfEmpty()
                            join like in _context.Likes on post.Id equals like.PostId
                            into postLikes
                            from postLike in postLikes.DefaultIfEmpty()
                            join comment in _context.Comments on post.Id equals comment.PostId
                            into postComments
                            from postComment in postComments.DefaultIfEmpty()
                            group new { post, postLike, postComment } by new { userPost.Id, userPost.Name, post.Description, post.MediaUrl, post.DateCreated } into grouped
                            select new PostGetDto
                            (
                                grouped.Key.Id,
                                grouped.Key.Name,
                                grouped.Key.Description,
                                grouped.Key.MediaUrl,
                                grouped.Key.DateCreated,
                                grouped.Count(p => p.postLike != null),
                                grouped.Count(p => p.postComment != null)
                            );

            var postsInfoList = postsInfo.ToList();

            return postsInfoList.FirstOrDefault();
        }


        public async Task Add(PostAddDto postDto)
        {
            var newPost = new Post {

                Description = postDto.Description,
                MediaUrl = postDto.MediaUrl,
                DateCreated = DateTime.Now,
                UserId = postDto.UserId,
            };

            _context.Posts.AddAsync(newPost);
           await _context.SaveChangesAsync();
        }

        public async Task<PostUpdateDto> Update(PostUpdateDto postDto, Guid id)
        {
            var post = await _context.Posts.FindAsync(id);

            post.Description = postDto.Description ?? post.Description;
            post.MediaUrl = postDto.MediaUrl ?? post.MediaUrl;

            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task Delete(Guid Id)
        {
            var post = await _context.Posts.FindAsync(Id);

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
