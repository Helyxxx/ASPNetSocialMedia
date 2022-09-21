using ASPNetSocialMedia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASPNetSocialMedia.Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
               .HasMany(cur => cur.PostCommentList)
               .WithOne(rel => rel.CommentedPost)
               .HasForeignKey(fkey => fkey.PostId);
        }
    }
}
