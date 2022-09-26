using MessagePack;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ASPNetSocialMedia.Models
{
    public class Messages
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int? MessageId { get; set; }
        public string? MessageContent { get; set; }
        public string? WhoPosted { get; set; }

        public string? WhoReceived { get; set; }

        public int CreatePost()
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-ASPNetSocialMedia-2E74CB14-DD3A-4442-9DCF-EC4C63E8F3F6;Integrated Security=True");
            string query = "INSERT INTO dbo.PrivateMessage (PrivateMessageContent, WhoPosted,WhoReceived) VALUES ('" + MessageContent + "', ,'" + WhoPosted + "' , '" + WhoReceived + "');";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
