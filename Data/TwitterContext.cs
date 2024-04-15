using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TwitterAPI.Configuration;
using TwitterAPI.Models;

namespace TwitterAPI.Data
{
    public class TwitterContext : DbContext
    {

        public TwitterContext(DbContextOptions<TwitterContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follower> Followers { get; set; } // Seguidores        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property("Id").HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<Post>().Property("Id").HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<Comment>().Property("Id").HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<Like>().Property("Id").HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            modelBuilder.Entity<Follower>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.User)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.UserFollow)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.UserFollowId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Likes)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Likes) // Um post pode ter muitos likes
                .WithOne(l => l.Post)
                .HasForeignKey(l => l.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
