using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPNetSocialMedia.Models;

namespace ASPNetSocialMedia.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ASPNetSocialMedia.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ASPNetSocialMedia.Models.Post> Post { get; set; }
        public DbSet<ASPNetSocialMedia.Models.FriendRelation> FriendRelation { get; set; }
        public DbSet<ASPNetSocialMedia.Models.CloseFriendRelation> CloseFriendRelation { get; set; }
        public DbSet<ASPNetSocialMedia.Models.Messages> Messages { get; set; }
        public DbSet<ASPNetSocialMedia.Models.UserFeedback> UserFeedback { get; set; }
       
    }
}