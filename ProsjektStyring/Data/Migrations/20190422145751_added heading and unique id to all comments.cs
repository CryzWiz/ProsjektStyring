using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsjektStyring.Data.Migrations
{
    public partial class addedheadinganduniqueidtoallcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentHeading",
                table: "ProjectTaskComment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unique_IdString",
                table: "ProjectTaskComment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentHeading",
                table: "ProjectCycleComment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unique_IdString",
                table: "ProjectCycleComment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unique_IdString",
                table: "ProjectComment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentHeading",
                table: "ProjectTaskComment");

            migrationBuilder.DropColumn(
                name: "Unique_IdString",
                table: "ProjectTaskComment");

            migrationBuilder.DropColumn(
                name: "CommentHeading",
                table: "ProjectCycleComment");

            migrationBuilder.DropColumn(
                name: "Unique_IdString",
                table: "ProjectCycleComment");

            migrationBuilder.DropColumn(
                name: "Unique_IdString",
                table: "ProjectComment");
        }
    }
}
