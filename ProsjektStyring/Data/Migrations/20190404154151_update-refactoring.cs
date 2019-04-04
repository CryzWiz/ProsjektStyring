using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsjektStyring.Data.Migrations
{
    public partial class updaterefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectTask");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskId",
                table: "ProjectTask",
                newName: "ProjectCycleTaskId");

            migrationBuilder.RenameColumn(
                name: "ProjectCycles",
                table: "Project",
                newName: "NumberOfProjectCycles");

            migrationBuilder.CreateTable(
                name: "ProjectTaskComment",
                columns: table => new
                {
                    ProjectTaskCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectCycleTaskId = table.Column<int>(nullable: false),
                    CommentRegistered = table.Column<DateTime>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskComment", x => x.ProjectTaskCommentId);
                    table.ForeignKey(
                        name: "FK_ProjectTaskComment_ProjectTask_ProjectCycleTaskId",
                        column: x => x.ProjectCycleTaskId,
                        principalTable: "ProjectTask",
                        principalColumn: "ProjectCycleTaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskComment_ProjectCycleTaskId",
                table: "ProjectTaskComment",
                column: "ProjectCycleTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTaskComment");

            migrationBuilder.RenameColumn(
                name: "ProjectCycleTaskId",
                table: "ProjectTask",
                newName: "ProjectTaskId");

            migrationBuilder.RenameColumn(
                name: "NumberOfProjectCycles",
                table: "Project",
                newName: "ProjectCycles");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ProjectTask",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTask",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
