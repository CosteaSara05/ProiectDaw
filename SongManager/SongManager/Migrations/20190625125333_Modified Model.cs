using Microsoft.EntityFrameworkCore.Migrations;

namespace SongManager.Migrations
{
    public partial class ModifiedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YoutubeLink",
                table: "Song",
                newName: "Youtubelink");

            migrationBuilder.RenameColumn(
                name: "SongName",
                table: "Song",
                newName: "Songname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Youtubelink",
                table: "Song",
                newName: "YoutubeLink");

            migrationBuilder.RenameColumn(
                name: "Songname",
                table: "Song",
                newName: "SongName");
        }
    }
}
