using ASPNetSocialMedia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASPNetSocialMedia.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .HasMany(cur => cur.Photos)
                .WithOne(rel => rel.UsersPicture)
                .HasForeignKey(fkey => fkey.UserId);

            builder
                .HasMany(cur => cur.Posts)
                .WithOne(rel => rel.PostUser)
                .HasForeignKey(fkey => fkey.UserID);

            builder
                .HasMany(cur => cur.Comments)
                .WithOne(rel => rel.CommentUser)
                .HasForeignKey(fkey => fkey.UserId);
        }
    }
}
