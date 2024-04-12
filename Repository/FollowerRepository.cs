using Microsoft.EntityFrameworkCore;
using System.Linq;
using TwitterAPI.Contracts;
using TwitterAPI.Data;
using TwitterAPI.Models;
using TwitterAPI.Models.FollowerDto;

namespace TwitterAPI.Repository
{
    public class FollowerRepository : IFollowerRepository
    {

        private readonly TwitterContext _context;

        public FollowerRepository(TwitterContext context)
        {
            _context = context;
        }

        // Seguir
        public async Task Follow(FollowerDto followerDto)
        {
            var newFollow = new Follower
            {

                UserId = followerDto.UserId,
                UserFollowId = followerDto.UserFollowId,
                DateFollowed = DateTime.UtcNow

            };

            _context.Followers.Add(newFollow);
            await _context.SaveChangesAsync(); 
        }

        // Parar Seguir
        public async Task UnFollow(Guid Id)
        {
            var follow = await _context.Followers.FindAsync(Id);

            _context.Followers.Remove(follow); 
            await _context.SaveChangesAsync();
        }

        // Retorna a qtd de seguidores e seguidos de um usuário
        public async Task<GetUserResumeFollowsDto> GetResumeFollows(Guid Id)
        {
            var query = from user in _context.Users
            where user.Id == Id
                        join follower in _context.Followers on user.Id equals follower.UserId into userFollows
                        from userFollow in userFollows.DefaultIfEmpty()
                        join follower2 in _context.Followers on user.Id equals follower2.UserFollowId into userFollowers
                        from userFollower in userFollowers.DefaultIfEmpty()
                        group new { userFollow, userFollower } by new { user.Id } into grouped
                        select new GetUserResumeFollowsDto
                        (
                            
                            
                            grouped.Select(g => g.userFollower.Id).Distinct().Count(),
                            grouped.Select(g => g.userFollow.Id).Distinct().Count()
                        );


            var useuserFollows = query.ToList();

            return useuserFollows.FirstOrDefault();
        }

        // Retorna lista de seguidores de um usuário
        public async Task<IEnumerable<GetFollowersDto>> GetFollowers(Guid Id)
        {
            var query = from user in _context.Users
                        join follower in _context.Followers on user.Id equals follower.UserId
                        where follower.UserFollowId == Id
                        select new GetFollowersDto
                        (
                            user.Id,
                            user.Name
                        );            


            var followers = query.ToList();

            return followers;
        }


        // Retorna lista de seguidos de um usuário
        public async Task<IEnumerable<GetFollowersDto>> GetFollows(Guid Id)
        {
            var query = from user in _context.Users
                        join follower in _context.Followers on user.Id equals follower.UserFollowId
                        where follower.UserId == Id
                        select new GetFollowersDto
                        (
                         user.Id,
                         user.Name
                        );


            var follows = query.ToList();

            return follows;
        }

    }
}
