using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPNetSocialMedia.Models;
using ASPNetSocialMedia.Data.Configuration;

namespace ASPNetSocialMedia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ASPNetSocialMedia.Models.User> User { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ASPNetSocialMedia.Models.Friendship> Friendship { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());

            base.OnModelCreating(builder);
        }
    }
}