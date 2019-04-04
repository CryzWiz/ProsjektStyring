using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsjektStyring.Data.Migrations
{
    public partial class addedprojectCycles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask");

            migrationBuilder.RenameColumn(
                name: "ProjectCycle",
                table: "ProjectTask",
                newName: "ProsentageDone");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ProjectTask",
                newName: "TaskCompleted");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Project",
                newName: "ProjectCompleted");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectTask",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProjectCycleId",
                table: "ProjectTask",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TaskActive",
                table: "ProjectTask",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProjectActive",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectPlannedEnd",
                table: "Project",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectPlannedStart",
                table: "Project",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ProjectCycle",
                columns: table => new
                {
                    ProjectCycleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unique_CycleIdString = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    CycleName = table.Column<string>(nullable: true),
                    CycleDescription = table.Column<string>(nullable: true),
                    CycleNumber = table.Column<int>(nullable: false),
                    CycleActive = table.Column<bool>(nullable: false),
                    CycleFinished = table.Column<bool>(nullable: false),
                    CycleRegistered = table.Column<DateTime>(nullable: false),
                    CyclePlannedStart = table.Column<DateTime>(nullable: false),
                    CycleStart = table.Column<DateTime>(nullable: false),
                    CyclePlannedEnd = table.Column<DateTime>(nullable: false),
                    CycleEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCycle", x => x.ProjectCycleId);
                    table.ForeignKey(
                        name: "FK_ProjectCycle_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectCycleId",
                table: "ProjectTask",
                column: "ProjectCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCycle_ProjectId",
                table: "ProjectCycle",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_ProjectCycle_ProjectCycleId",
                table: "ProjectTask",
                column: "ProjectCycleId",
                principalTable: "ProjectCycle",
                principalColumn: "ProjectCycleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_ProjectCycle_ProjectCycleId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropTable(
                name: "ProjectCycle");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTask_ProjectCycleId",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "ProjectCycleId",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "TaskActive",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "ProjectActive",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectPlannedEnd",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectPlannedStart",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "TaskCompleted",
                table: "ProjectTask",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ProsentageDone",
                table: "ProjectTask",
                newName: "ProjectCycle");

            migrationBuilder.RenameColumn(
                name: "ProjectCompleted",
                table: "Project",
                newName: "Active");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectTask",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
