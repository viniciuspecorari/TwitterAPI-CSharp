namespace TwitterAPI.Models
{
    public class GetPost
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public int QtdLikes { get; set; }
        public int QtdComments { get; set; }
    }
}
