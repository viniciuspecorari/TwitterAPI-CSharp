namespace TwitterAPI.Models
{
    public class Like
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }

    }
}
