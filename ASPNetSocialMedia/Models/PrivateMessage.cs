using Microsoft.Data.SqlClient;

namespace ASPNetSocialMedia.Models
{
    public class PrivateMessage
    {
        public int? PrivateMessageId { get; set; }
        public string? PrivateMessageContent { get; set; }
        public string? WhoPosted { get; set; }

        public int CreatePost()
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-ASPNetSocialMedia-2E74CB14-DD3A-4442-9DCF-EC4C63E8F3F6;Integrated Security=True");
            string query = "INSERT INTO dbo.PrivateMessage (PrivateMessageContent, WhoPosted) VALUES ('" + PrivateMessageContent + "', '" + WhoPosted + "');";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
