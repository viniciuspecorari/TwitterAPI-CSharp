namespace TwitterAPI.Models.FollowerDto
{
    public record GetUserResumeFollowsDto(int QtdFollowers, int QtdFollows)
    {

        public static implicit operator GetUserResumeFollowsDto(GetUserResumeFollows entity)
        {
            return new GetUserResumeFollowsDto(entity.QtdFollowers, entity.QtdFollows);
        }

    }
}
