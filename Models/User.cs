using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace TwitterAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? Role { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Password { get; set; }
        public string? ProfilePicture { get; set; } = null;
        public string? ProfileCover { get; set; } = null;

        [MaxLength(280)]
        public string? ProfileDescription { get; set; } = null;
        public DateTime RegisterDateTime { get; set; }

        // Um para Muitos
        public ICollection<Post> Posts { get; } = new List<Post>();
        public ICollection<Like> Likes { get; } = new List<Like>();
        public ICollection<Comment> Comments { get; } = new List<Comment>();

        public ICollection<Follower> Followers { get; set; } = new List<Follower>();
        public ICollection<Follower> Following { get; set; } = new List<Follower>();

    }
}
