using TwitterAPI.Models.FollowerDto;

namespace TwitterAPI.Contracts
{
    public interface IFollowerRepository
    {

        public Task Follow(FollowerDto followDto);
        public Task UnFollow(Guid Id);

        // Retorna a qtd de seguidores e seguidos de um usuário
        public Task<GetUserResumeFollowsDto> GetResumeFollows(Guid UserId);

        // Retorna lista de seguidores de um usuário
        public Task<IEnumerable<GetFollowersDto>> GetFollowers(Guid UserId);

        // Retorna lista de seguidos de um usuário
        public Task<IEnumerable<GetFollowersDto>> GetFollows(Guid UserId);


    }
}
