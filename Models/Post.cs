using System.Reflection.Metadata;
using System.Xml.Linq;

namespace TwitterAPI.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string? MediaUrl { get; set; } = null;

        public DateTime DateCreated { get; set; }

        // Um para Muitos
        public Guid UserId { get; set; }
        public User User { get; set; }        

        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Comments { get; } = new List<Comment>();

    }
}
