using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsjektStyring.Migrations
{
    public partial class i3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unique_ProjectIdString = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(maxLength: 60, nullable: false),
                    ProjectClient = table.Column<string>(maxLength: 60, nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    NumberOfProjectCycles = table.Column<int>(nullable: false),
                    ProjectActive = table.Column<bool>(nullable: false),
                    ProjectCompleted = table.Column<bool>(nullable: false),
                    ProjectPlannedStart = table.Column<DateTime>(nullable: false),
                    ProjectStart = table.Column<DateTime>(nullable: false),
                    ProjectPlannedEnd = table.Column<DateTime>(nullable: false),
                    ProjectEnd = table.Column<DateTime>(nullable: false),
                    ProjectRegistered = table.Column<DateTime>(nullable: false),
                    ProjectCreatedByUser = table.Column<string>(nullable: true),
                    ProjectClosedByUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectComment",
                columns: table => new
                {
                    ProjectCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    CommentRegistered = table.Column<DateTime>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    CommentHeading = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Unique_IdString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectComment", x => x.ProjectCommentId);
                    table.ForeignKey(
                        name: "FK_ProjectComment_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCycle",
                columns: table => new
                {
                    ProjectCycleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unique_CycleIdString = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    CycleName = table.Column<string>(maxLength: 60, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ProjectCycleComment",
                columns: table => new
                {
                    ProjectCycleCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectCycleId = table.Column<int>(nullable: false),
                    CommentRegistered = table.Column<DateTime>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    CommentHeading = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Unique_IdString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCycleComment", x => x.ProjectCycleCommentId);
                    table.ForeignKey(
                        name: "FK_ProjectCycleComment_ProjectCycle_ProjectCycleId",
                        column: x => x.ProjectCycleId,
                        principalTable: "ProjectCycle",
                        principalColumn: "ProjectCycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCycleTask",
                columns: table => new
                {
                    ProjectCycleTaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unique_TaskIdString = table.Column<string>(nullable: true),
                    ProjectCycleId = table.Column<int>(nullable: false),
                    TaskName = table.Column<string>(nullable: false),
                    TaskDescription = table.Column<string>(nullable: true),
                    TaskStatus = table.Column<string>(nullable: true),
                    TaskUnderUser = table.Column<string>(nullable: true),
                    LockedUnderUser = table.Column<bool>(nullable: false),
                    TaskActive = table.Column<bool>(nullable: false),
                    TaskCompleted = table.Column<bool>(nullable: false),
                    PlannedHours = table.Column<double>(nullable: false),
                    TotalHoursSpent = table.Column<double>(nullable: false),
                    ProsentageDone = table.Column<int>(nullable: false),
                    TaskRegistered = table.Column<DateTime>(nullable: false),
                    TaskDueDate = table.Column<DateTime>(nullable: false),
                    TaskCleared = table.Column<DateTime>(nullable: false),
                    TaskClearedByUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCycleTask", x => x.ProjectCycleTaskId);
                    table.ForeignKey(
                        name: "FK_ProjectCycleTask_ProjectCycle_ProjectCycleId",
                        column: x => x.ProjectCycleId,
                        principalTable: "ProjectCycle",
                        principalColumn: "ProjectCycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCycleTaskComment",
                columns: table => new
                {
                    ProjectCycleTaskCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectCycleTaskId = table.Column<int>(nullable: false),
                    CommentRegistered = table.Column<DateTime>(nullable: false),
                    ByUser = table.Column<string>(nullable: true),
                    CommentHeading = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Unique_IdString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCycleTaskComment", x => x.ProjectCycleTaskCommentId);
                    table.ForeignKey(
                        name: "FK_ProjectCycleTaskComment_ProjectCycleTask_ProjectCycleTaskId",
                        column: x => x.ProjectCycleTaskId,
                        principalTable: "ProjectCycleTask",
                        principalColumn: "ProjectCycleTaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComment_ProjectId",
                table: "ProjectComment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCycle_ProjectId",
                table: "ProjectCycle",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCycleComment_ProjectCycleId",
                table: "ProjectCycleComment",
                column: "ProjectCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCycleTask_ProjectCycleId",
                table: "ProjectCycleTask",
                column: "ProjectCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCycleTaskComment_ProjectCycleTaskId",
                table: "ProjectCycleTaskComment",
                column: "ProjectCycleTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProjectComment");

            migrationBuilder.DropTable(
                name: "ProjectCycleComment");

            migrationBuilder.DropTable(
                name: "ProjectCycleTaskComment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProjectCycleTask");

            migrationBuilder.DropTable(
                name: "ProjectCycle");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
