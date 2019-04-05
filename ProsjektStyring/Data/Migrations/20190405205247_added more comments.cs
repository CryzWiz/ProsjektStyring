using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsjektStyring.Data.Migrations
{
    public partial class addedmorecomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycle_Project_ProjectId",
                table: "ProjectCycle");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_ProjectCycle_ProjectCycleId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskComment_ProjectTask_ProjectCycleTaskId",
                table: "ProjectTaskComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask");

            migrationBuilder.RenameTable(
                name: "ProjectTask",
                newName: "ProjectCycleTask");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ProjectCycleId",
                table: "ProjectCycleTask",
                newName: "IX_ProjectCycleTask_ProjectCycleId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCycleTaskId",
                table: "ProjectTaskComment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Unique_TaskIdString",
                table: "ProjectTaskComment",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectCycle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Unique_ProjectIdString",
                table: "ProjectCycle",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCycleId",
                table: "ProjectCycleTask",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Unique_CycleIdString",
                table: "ProjectCycleTask",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectCycleTask",
                table: "ProjectCycleTask",
                column: "ProjectCycleTaskId");

            migrationBuilder.CreateTable(
                name: "ProjectComment",
                columns: table => new
                {
                    ProjectCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unique_ProjectIdString = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    CommentRegistered = table.Column<DateTime>(nullable: false),
                    ReplyToComment = table.Column<int>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectComment", x => x.ProjectCommentId);
                    table.ForeignKey(
                        name: "FK_ProjectComment_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCycleComment",
                columns: table => new
                {
                    ProjectCycleCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unique_CycleIdString = table.Column<string>(nullable: true),
                    ProjectCycleId = table.Column<int>(nullable: true),
                    CommentRegistered = table.Column<DateTime>(nullable: false),
                    ReplyToComment = table.Column<int>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCycleComment", x => x.ProjectCycleCommentId);
                    table.ForeignKey(
                        name: "FK_ProjectCycleComment_ProjectCycle_ProjectCycleId",
                        column: x => x.ProjectCycleId,
                        principalTable: "ProjectCycle",
                        principalColumn: "ProjectCycleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComment_ProjectId",
                table: "ProjectComment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCycleComment_ProjectCycleId",
                table: "ProjectCycleComment",
                column: "ProjectCycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCycle_Project_ProjectId",
                table: "ProjectCycle",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCycleTask_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleTask",
                column: "ProjectCycleId",
                principalTable: "ProjectCycle",
                principalColumn: "ProjectCycleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskComment_ProjectCycleTask_ProjectCycleTaskId",
                table: "ProjectTaskComment",
                column: "ProjectCycleTaskId",
                principalTable: "ProjectCycleTask",
                principalColumn: "ProjectCycleTaskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycle_Project_ProjectId",
                table: "ProjectCycle");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycleTask_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskComment_ProjectCycleTask_ProjectCycleTaskId",
                table: "ProjectTaskComment");

            migrationBuilder.DropTable(
                name: "ProjectComment");

            migrationBuilder.DropTable(
                name: "ProjectCycleComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectCycleTask",
                table: "ProjectCycleTask");

            migrationBuilder.DropColumn(
                name: "Unique_TaskIdString",
                table: "ProjectTaskComment");

            migrationBuilder.DropColumn(
                name: "Unique_ProjectIdString",
                table: "ProjectCycle");

            migrationBuilder.DropColumn(
                name: "Unique_CycleIdString",
                table: "ProjectCycleTask");

            migrationBuilder.RenameTable(
                name: "ProjectCycleTask",
                newName: "ProjectTask");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectCycleTask_ProjectCycleId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ProjectCycleId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCycleTaskId",
                table: "ProjectTaskComment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectCycle",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCycleId",
                table: "ProjectTask",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask",
                column: "ProjectCycleTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCycle_Project_ProjectId",
                table: "ProjectCycle",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_ProjectCycle_ProjectCycleId",
                table: "ProjectTask",
                column: "ProjectCycleId",
                principalTable: "ProjectCycle",
                principalColumn: "ProjectCycleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskComment_ProjectTask_ProjectCycleTaskId",
                table: "ProjectTaskComment",
                column: "ProjectCycleTaskId",
                principalTable: "ProjectTask",
                principalColumn: "ProjectCycleTaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
