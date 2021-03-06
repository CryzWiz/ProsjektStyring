﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProsjektStyring.Data;

namespace ProsjektStyring.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190424220113_i3")]
    partial class i3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProsjektStyring.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("EmployeeId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProsjektStyring.Data.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfProjectCycles");

                    b.Property<bool>("ProjectActive");

                    b.Property<string>("ProjectClient")
                        .HasMaxLength(60);

                    b.Property<string>("ProjectClosedByUser");

                    b.Property<bool>("ProjectCompleted");

                    b.Property<string>("ProjectCreatedByUser");

                    b.Property<string>("ProjectDescription");

                    b.Property<DateTime>("ProjectEnd");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("ProjectPlannedEnd");

                    b.Property<DateTime>("ProjectPlannedStart");

                    b.Property<DateTime>("ProjectRegistered");

                    b.Property<DateTime>("ProjectStart");

                    b.Property<string>("Unique_ProjectIdString");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectComment", b =>
                {
                    b.Property<int>("ProjectCommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ByUser");

                    b.Property<string>("Comment");

                    b.Property<string>("CommentHeading");

                    b.Property<DateTime>("CommentRegistered");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Unique_IdString");

                    b.HasKey("ProjectCommentId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectComment");
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectCycle", b =>
                {
                    b.Property<int>("ProjectCycleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CycleActive");

                    b.Property<string>("CycleDescription");

                    b.Property<DateTime>("CycleEnd");

                    b.Property<bool>("CycleFinished");

                    b.Property<string>("CycleName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("CycleNumber");

                    b.Property<DateTime>("CyclePlannedEnd");

                    b.Property<DateTime>("CyclePlannedStart");

                    b.Property<DateTime>("CycleRegistered");

                    b.Property<DateTime>("CycleStart");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Unique_CycleIdString");

                    b.HasKey("ProjectCycleId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectCycle");
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectCycleComment", b =>
                {
                    b.Property<int>("ProjectCycleCommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ByUser");

                    b.Property<string>("Comment");

                    b.Property<string>("CommentHeading");

                    b.Property<DateTime>("CommentRegistered");

                    b.Property<int>("ProjectCycleId");

                    b.Property<string>("Unique_IdString");

                    b.HasKey("ProjectCycleCommentId");

                    b.HasIndex("ProjectCycleId");

                    b.ToTable("ProjectCycleComment");
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectCycleTask", b =>
                {
                    b.Property<int>("ProjectCycleTaskId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("LockedUnderUser");

                    b.Property<double>("PlannedHours");

                    b.Property<int>("ProjectCycleId");

                    b.Property<int>("ProsentageDone");

                    b.Property<bool>("TaskActive");

                    b.Property<DateTime>("TaskCleared");

                    b.Property<string>("TaskClearedByUser");

                    b.Property<bool>("TaskCompleted");

                    b.Property<string>("TaskDescription");

                    b.Property<DateTime>("TaskDueDate");

                    b.Property<string>("TaskName")
                        .IsRequired();

                    b.Property<DateTime>("TaskRegistered");

                    b.Property<string>("TaskStatus");

                    b.Property<string>("TaskUnderUser");

                    b.Property<double>("TotalHoursSpent");

                    b.Property<string>("Unique_TaskIdString");

                    b.HasKey("ProjectCycleTaskId");

                    b.HasIndex("ProjectCycleId");

                    b.ToTable("ProjectCycleTask");
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectCycleTaskComment", b =>
                {
                    b.Property<int>("ProjectCycleTaskCommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ByUser");

                    b.Property<string>("Comment");

                    b.Property<string>("CommentHeading");

                    b.Property<DateTime>("CommentRegistered");

                    b.Property<int>("ProjectCycleTaskId");

                    b.Property<string>("Unique_IdString");

                    b.HasKey("ProjectCycleTaskCommentId");

                    b.HasIndex("ProjectCycleTaskId");

                    b.ToTable("ProjectCycleTaskComment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProsjektStyring.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProsjektStyring.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProsjektStyring.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProsjektStyring.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectComment", b =>
                {
                    b.HasOne("ProsjektStyring.Data.Project")
                        .WithMany("ProjectComments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectCycle", b =>
                {
                    b.HasOne("ProsjektStyring.Data.Project", "Project")
                        .WithMany("ProjectCycles")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectCycleComment", b =>
                {
                    b.HasOne("ProsjektStyring.Data.ProjectCycle")
                        .WithMany("ProjectCycleComments")
                        .HasForeignKey("ProjectCycleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectCycleTask", b =>
                {
                    b.HasOne("ProsjektStyring.Data.ProjectCycle", "ProjectCycle")
                        .WithMany("ProjectCycleTasks")
                        .HasForeignKey("ProjectCycleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProsjektStyring.Data.ProjectCycleTaskComment", b =>
                {
                    b.HasOne("ProsjektStyring.Data.ProjectCycleTask")
                        .WithMany("ProjectTaskComments")
                        .HasForeignKey("ProjectCycleTaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
