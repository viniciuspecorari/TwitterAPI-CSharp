namespace TwitterAPI.Models
{
    public class Follower
    {
        public Guid Id { get; set; }

        public DateTime DateFollowed { get; set; }
        public Guid UserId { get; set; } // Usuário Id
        public Guid UserFollowId { get; set; } // Usuário seguido


        public User User { get; set; }
        public User UserFollow { get; set; }
    }
}
