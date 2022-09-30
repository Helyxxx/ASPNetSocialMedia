using System.ComponentModel.DataAnnotations;

namespace ASPNetSocialMedia.Models
{
    public class UserFeedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string FeedbackName { get; set; }
        public string FeedbackEmail { get; set; }
        public string FeedbackMessage { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public UserFeedback()
        {
            CreationDate = DateTime.Now;
        }
    }
}
