using System.ComponentModel.DataAnnotations;

namespace ASPNetSocialMedia.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public int UserID { get; set; }
        public User PostUser { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Comment> PostCommentList { get; set; }

    }
}
