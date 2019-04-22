using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsjektStyring.Data.Migrations
{
    public partial class addedCommentHeading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReplyToComment",
                table: "ProjectCycleComment");

            migrationBuilder.DropColumn(
                name: "ReplyToComment",
                table: "ProjectComment");

            migrationBuilder.AddColumn<string>(
                name: "CommentHeading",
                table: "ProjectComment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentHeading",
                table: "ProjectComment");

            migrationBuilder.AddColumn<int>(
                name: "ReplyToComment",
                table: "ProjectCycleComment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReplyToComment",
                table: "ProjectComment",
                nullable: false,
                defaultValue: 0);
        }
    }
}
