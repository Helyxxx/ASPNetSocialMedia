using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPNetSocialMedia.Models;
using ASPNetSocialMedia.Data.Configuration;

namespace ASPNetSocialMedia.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ASPNetSocialMedia.Models.User> User { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ASPNetSocialMedia.Models.Friendship> Friendship { get; set; }
        public DbSet<ASPNetSocialMedia.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ASPNetSocialMedia.Models.Post> Post { get; set; }
        public DbSet<ASPNetSocialMedia.Models.FriendRelation> FriendRelation { get; set; }
        public DbSet<ASPNetSocialMedia.Models.CloseFriendRelation> CloseFriendRelation { get; set; }
        public DbSet<ASPNetSocialMedia.Models.PrivateMessage> PrivateMessage { get; set; }
        public DbSet<ASPNetSocialMedia.Models.Messages> Messages { get; set; }
    }
}