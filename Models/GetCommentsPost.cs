namespace TwitterAPI.Models
{
    public class GetCommentsPost
    {
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }

        public string UserName { get; set; }
        public string UserPicture { get; set; }
        public Guid PostId { get; set; }
    }
}
