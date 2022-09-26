using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetSocialMedia.Models
{
    public class CloseFriendRelation
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CloseFriendRelationId { get; set; }
        public string? CloseUserEmail { get; set; }
        public string? CloseFriendEmail { get; set; }
    }
}
