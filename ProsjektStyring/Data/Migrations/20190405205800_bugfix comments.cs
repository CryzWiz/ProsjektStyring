using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsjektStyring.Data.Migrations
{
    public partial class bugfixcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComment_Project_ProjectId",
                table: "ProjectComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycle_Project_ProjectId",
                table: "ProjectCycle");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycleComment_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycleTask_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskComment_ProjectCycleTask_ProjectCycleTaskId",
                table: "ProjectTaskComment");

            migrationBuilder.DropColumn(
                name: "Unique_TaskIdString",
                table: "ProjectTaskComment");

            migrationBuilder.DropColumn(
                name: "Unique_CycleIdString",
                table: "ProjectCycleTask");

            migrationBuilder.DropColumn(
                name: "Unique_CycleIdString",
                table: "ProjectCycleComment");

            migrationBuilder.DropColumn(
                name: "Unique_ProjectIdString",
                table: "ProjectCycle");

            migrationBuilder.DropColumn(
                name: "Unique_ProjectIdString",
                table: "ProjectComment");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCycleTaskId",
                table: "ProjectTaskComment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCycleId",
                table: "ProjectCycleTask",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCycleId",
                table: "ProjectCycleComment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectCycle",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectComment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComment_Project_ProjectId",
                table: "ProjectComment",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCycle_Project_ProjectId",
                table: "ProjectCycle",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCycleComment_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleComment",
                column: "ProjectCycleId",
                principalTable: "ProjectCycle",
                principalColumn: "ProjectCycleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCycleTask_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleTask",
                column: "ProjectCycleId",
                principalTable: "ProjectCycle",
                principalColumn: "ProjectCycleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTaskComment_ProjectCycleTask_ProjectCycleTaskId",
                table: "ProjectTaskComment",
                column: "ProjectCycleTaskId",
                principalTable: "ProjectCycleTask",
                principalColumn: "ProjectCycleTaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComment_Project_ProjectId",
                table: "ProjectComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycle_Project_ProjectId",
                table: "ProjectCycle");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycleComment_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCycleTask_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTaskComment_ProjectCycleTask_ProjectCycleTaskId",
                table: "ProjectTaskComment");

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
                name: "ProjectCycleId",
                table: "ProjectCycleTask",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Unique_CycleIdString",
                table: "ProjectCycleTask",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCycleId",
                table: "ProjectCycleComment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Unique_CycleIdString",
                table: "ProjectCycleComment",
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

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectComment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Unique_ProjectIdString",
                table: "ProjectComment",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComment_Project_ProjectId",
                table: "ProjectComment",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCycle_Project_ProjectId",
                table: "ProjectCycle",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCycleComment_ProjectCycle_ProjectCycleId",
                table: "ProjectCycleComment",
                column: "ProjectCycleId",
                principalTable: "ProjectCycle",
                principalColumn: "ProjectCycleId",
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
    }
}
