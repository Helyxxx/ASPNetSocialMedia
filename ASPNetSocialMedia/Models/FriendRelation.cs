using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetSocialMedia.Models
{
    public class FriendRelation
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FriendRelationId { get; set; }
        public string? UserEmail { get; set; }
        public string? FriendEmail { get; set; }
    }
}
