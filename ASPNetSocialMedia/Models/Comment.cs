using System.ComponentModel.DataAnnotations;

namespace ASPNetSocialMedia.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public User CommentUser { get; set; }
        public int PostId { get; set; }
        public Post CommentedPost { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
