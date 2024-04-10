using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TwitterAPI.Configuration;
using TwitterAPI.Models.Entities;

namespace TwitterAPI.Data
{
    public class TwitterContext : DbContext
    {

        public TwitterContext(DbContextOptions<TwitterContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property("Id").HasDefaultValueSql("newsequentialid()");            
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
