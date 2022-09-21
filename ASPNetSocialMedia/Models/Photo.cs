using ASPNetSocialMedia.Data;
using System.ComponentModel.DataAnnotations;

namespace ASPNetSocialMedia.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.MaxPhotoLength)]
        public byte[] PhotoAsBytes { get; set; }

        public int UserId { get; set; }

        public User UsersPicture { get; set; }

        public int? PostId { get; set; }

        public Post PostPhoto { get; set; }

        public bool IsProfilePicture { get; set; }
    }
}
