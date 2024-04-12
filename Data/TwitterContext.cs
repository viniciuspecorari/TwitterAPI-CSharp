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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasMany(u => u.Posts)
                      .WithOne(p => p.User)
                      .HasForeignKey(p => p.UserId);
                entity.HasMany(u => u.Likes)
                      .WithOne(l => l.User)
                      .HasForeignKey(l => l.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(p => p.User)
                      .WithMany(u => u.Posts)
                      .HasForeignKey(p => p.UserId);
                entity.HasOne(p => p.Like)
                      .WithOne(l => l.Post)
                      .HasForeignKey<Like>(l => l.PostId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.HasOne(l => l.User)
                      .WithMany(u => u.Likes)
                      .HasForeignKey(l => l.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(l => l.Post)
                      .WithOne(p => p.Like)
                      .HasForeignKey<Like>(l => l.PostId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasMany(u => u.Comments)
                      .WithOne(c => c.User)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.NoAction); // Definindo a ação de exclusão
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasMany(p => p.Comments)
                      .WithOne(c => c.Post)
                      .HasForeignKey(c => c.PostId)
                      .OnDelete(DeleteBehavior.NoAction); // Definindo a ação de exclusão
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.NoAction); // Definindo a ação de exclusão
                entity.HasOne(c => c.Post)
                      .WithMany(p => p.Comments)
                      .HasForeignKey(c => c.PostId)
                      .OnDelete(DeleteBehavior.NoAction); // Definindo a ação de exclusão
            });



            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            

            //Conventions.Remove<ManyToManyCascadeDeleteConve‌​ntion>();
        }
    }
}
