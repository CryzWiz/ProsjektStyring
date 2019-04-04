using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsjektStyring.Data.Migrations
{
    public partial class addedtaskComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStarted",
                table: "ProjectTask",
                newName: "TaskDueDate");

            migrationBuilder.AddColumn<bool>(
                name: "LockedUnderUser",
                table: "ProjectTask",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "PlannedHours",
                table: "ProjectTask",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHoursSpent",
                table: "ProjectTask",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockedUnderUser",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "PlannedHours",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "TotalHoursSpent",
                table: "ProjectTask");

            migrationBuilder.RenameColumn(
                name: "TaskDueDate",
                table: "ProjectTask",
                newName: "TaskStarted");
        }
    }
}
