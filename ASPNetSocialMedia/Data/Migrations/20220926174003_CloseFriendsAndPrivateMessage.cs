using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetSocialMedia.Data.Migrations
{
    public partial class CloseFriendsAndPrivateMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CloseFriendRelation",
                columns: table => new
                {
                    CloseFriendRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CloseUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseFriendEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseFriendRelation", x => x.CloseFriendRelationId);
                });

            migrationBuilder.CreateTable(
                name: "PrivateMessage",
                columns: table => new
                {
                    PrivateMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivateMessageContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhoPosted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessage", x => x.PrivateMessageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CloseFriendRelation");

            migrationBuilder.DropTable(
                name: "PrivateMessage");
        }
    }
}
