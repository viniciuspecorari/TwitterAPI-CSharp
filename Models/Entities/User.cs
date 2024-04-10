using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace TwitterAPI.Models.Entities
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

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique(); // Propriedade para definir como unique
        }
    }
}
