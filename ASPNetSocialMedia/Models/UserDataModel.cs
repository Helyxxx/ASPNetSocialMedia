
using Microsoft.Data.SqlClient;

namespace ASPNetSocialMedia.Models
{
    public class UserDataModel
    {
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? ProfileImage { get; set; }
        public string? Biography { get; set; }

        public int SaveDetails()
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-ASPNetSocialMedia-2E74CB14-DD3A-4442-9DCF-EC4C63E8F3F6;Integrated Security=True");
            string query = "Update dbo.AspNetUsers set FirstName = " + "'" +  FirstName + "', LastName = '" + LastName + "', ProfileImage = '" + ProfileImage + "', Biography = '" + Biography + " ' WHERE Id='" + UserId + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
