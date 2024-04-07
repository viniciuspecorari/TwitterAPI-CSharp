using Microsoft.EntityFrameworkCore;
using TwitterAPI.Models.Entities;

namespace TwitterAPI.Data
{
    public class TwitterContext : DbContext
    {

        public TwitterContext(DbContextOptions<TwitterContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
