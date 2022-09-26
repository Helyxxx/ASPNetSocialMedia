using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASPNetSocialMedia.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser(string? firstName, string? lastName, DateTime? dateOfBirth, string? biography, string? profileImage, string? address, int? age)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Biography = biography;
            ProfileImage = profileImage;
            Address = address;
            Age = age;
        }

        public ApplicationUser()
        {

        }

        public ApplicationUser(string? firstName)
        {
            FirstName = firstName;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string? Biography { get; set; }
        public string? ProfileImage { get; set; } = "https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png";
        public string? Address { get; set; }
        public int? Age { get; set; }

        
    }
}
