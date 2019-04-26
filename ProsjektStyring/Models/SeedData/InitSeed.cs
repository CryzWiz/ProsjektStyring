using Microsoft.AspNetCore.Identity;
using ProsjektStyring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsjektStyring.Models.SeedData
{
    public class InitSeed
    {
        /**
         * Initialize the db with some starter data.
         * For a production setting, comment out everything except:
         * - CreateRolesAsync()
         * - CreateAdminAsync()
         * 
         * These are needed for:
         * a) The site to run
         * b) For you to have some way of accessing it as admin
         * 
         */
        public static async Task InitializeAsync(ApplicationDbContext context,
            UserManager<ApplicationUser> uM,
            RoleManager<IdentityRole> rM)
        {
            // If we dont have any roles, add them
            if (!context.Roles.Any())
            {
                await CreateRolesAsync(context, rM);
            }
            // If we dont have a user, create some
            if (!context.Users.Any())
            {
                await CreateAdminAsync(context, uM);
                await CreateTeamLeader(context, uM);
                await CreateUser(context, uM);
                await CreateMember(context, uM);
            }
            // If we dont have any projects, create one
            if (!context.Project.Any())
            {
                // Add Project, ProjectCycle and a ProjectCycleTask
                await CreateProject(context, uM);
                // Create a init commet for each of them
                await AddComments(context, uM);
            }
        }

        /**
         * Create users, one for each Role
         */
        private static async Task CreateAdminAsync(ApplicationDbContext context, UserManager<ApplicationUser> uM)
        {
            DateTime regdate = DateTime.Now;
            var admin = new ApplicationUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Adminson",
                Active = true,
                RegistrationDate = DateTime.Now
            };
            await uM.CreateAsync(admin, "Password@123");
            context.SaveChanges();

            var aU = await uM.FindByEmailAsync(admin.Email);
            await uM.AddToRoleAsync(aU, RoleOptions.AdminRole);
            await context.SaveChangesAsync();
        }
        private static async Task CreateTeamLeader(ApplicationDbContext context, UserManager<ApplicationUser> uM)
        {
            DateTime regdate = DateTime.Now;
            var teamleder = new ApplicationUser
            {
                UserName = "teamleader@teamleader.com",
                Email = "teamleader@teamleader.com",
                FirstName = "Teamleader",
                LastName = "Teamleaderson",
                Active = true,
                RegistrationDate = DateTime.Now
            };
            await uM.CreateAsync(teamleder, "Password@123");
            context.SaveChanges();
            var aU = await uM.FindByEmailAsync(teamleder.Email);
            await uM.AddToRoleAsync(aU, RoleOptions.TeamLeaderRole);
            await context.SaveChangesAsync();
        }
        private static async Task CreateUser(ApplicationDbContext context, UserManager<ApplicationUser> uM)
        {
            DateTime regdate = DateTime.Now;
            var user = new ApplicationUser
            {
                UserName = "user@user.com",
                Email = "user@user.com",
                FirstName = "User",
                LastName = "Userson",
                Active = true,
                RegistrationDate = DateTime.Now
            };

            await uM.CreateAsync(user, "Password@123");
            context.SaveChanges();

            var aU = await uM.FindByEmailAsync(user.Email);
            await uM.AddToRoleAsync(aU, RoleOptions.UserRole);
            await context.SaveChangesAsync();
        }
        private static async Task CreateMember(ApplicationDbContext context, UserManager<ApplicationUser> uM)
        {
            DateTime regdate = DateTime.Now;
            var member = new ApplicationUser
            {
                UserName = "member@member.com",
                Email = "member@member.com",
                FirstName = "Member",
                LastName = "Memberson",
                Active = true,
                RegistrationDate = DateTime.Now
            };

            await uM.CreateAsync(member, "Password@123");
            context.SaveChanges();

            var aU = await uM.FindByEmailAsync(member.Email);
            await uM.AddToRoleAsync(aU, RoleOptions.MemberRole);
            await context.SaveChangesAsync();
        }

        /**
         * Create the different roles for the site
         */
        private static async Task CreateRolesAsync(ApplicationDbContext context, RoleManager<IdentityRole> rM)
        {
            await rM.CreateAsync(new IdentityRole(RoleOptions.AdminRole));
            await context.SaveChangesAsync();
            await rM.CreateAsync(new IdentityRole(RoleOptions.UserRole));
            await context.SaveChangesAsync();
            await rM.CreateAsync(new IdentityRole(RoleOptions.MemberRole));
            await context.SaveChangesAsync();
            await rM.CreateAsync(new IdentityRole(RoleOptions.TeamLeaderRole));
            await context.SaveChangesAsync();
        }

        /**
         * Create a project with a cycle and a task. And some comments for 
         * each of them.
         */
         private static async Task CreateProject(ApplicationDbContext context, UserManager<ApplicationUser> uM)
        {

            Project initProject = new Project { 
                ProjectName = "Testprosjekt",
                ProjectClient = "allanarnesen.com",
                ProjectDescription = "Test-prosjekt. Opprettet av SeedData",
                ProjectPlannedStart = DateTime.Now,
                ProjectPlannedEnd = DateTime.Now.AddDays(30),
                ProjectCreatedByUser = "admin@admin.com",
                ProjectRegistered = DateTime.Now,
                Unique_ProjectIdString = "exampleprojectguid",
                NumberOfProjectCycles = 1,
                ProjectActive = true,
                ProjectStart = DateTime.Now
            };
            context.Add(initProject);
            await context.SaveChangesAsync();

            ProjectCycle initCycle = new ProjectCycle
            {
                CycleName = "TestSyklus",
                CycleRegistered = DateTime.Now,
                Unique_CycleIdString = "examplecycleguid",
                CycleNumber = 1,
                CyclePlannedStart = DateTime.Now,
                CyclePlannedEnd = DateTime.Now.AddDays(30),
                CycleDescription = "Test-syklus. Opprettet av SeedData",
                ProjectId = 1,
                CycleActive = true,
                CycleStart = DateTime.Now
            };
            context.Add(initCycle);
            await context.SaveChangesAsync();

            ProjectCycleTask initTask = new ProjectCycleTask { 
                TaskActive = true,
                TaskDescription = "Test-oppgave. Opprettet av SeedData",
                TaskName = "TestOppgave",
                PlannedHours = 4.5,
                TaskCompleted = false,
                TotalHoursSpent = 0.0,
                TaskRegistered = DateTime.Now,
                TaskDueDate = DateTime.Now.AddDays(15),
                Unique_TaskIdString = "exampletaskguid",
                ProjectCycleId = 1               
            };

            context.Add(initTask);
            await context.SaveChangesAsync();

        }

        /**
         * Create a init comment to the project, projectcycle and the projectcycletask.
         */
        private static async Task AddComments(ApplicationDbContext context, UserManager<ApplicationUser> uM)
        {
            ProjectComment initProjectComment = new ProjectComment
            {
                CommentRegistered = DateTime.Now,
                ByUser = "admin@admin.com",
                Comment = "Opprettet av SeedData",
                CommentHeading = "Testkommentar",
                ProjectId = 1,
                Unique_IdString = "exampleprojectcommentguid"
            };
            context.Add(initProjectComment);
            await context.SaveChangesAsync();

            ProjectCycleComment initCycleComment = new ProjectCycleComment
            {
                CommentRegistered = DateTime.Now,
                ByUser = "admin@admin.com",
                Comment = "Opprettet av SeedData",
                CommentHeading = "Testkommentar",
                ProjectCycleId = 1,
                Unique_IdString = "exampleprojectcyclecommentguid"
            };
            context.Add(initCycleComment);
            await context.SaveChangesAsync();

            ProjectCycleTaskComment initTaskComment = new ProjectCycleTaskComment
            {
                CommentRegistered = DateTime.Now,
                ByUser = "admin@admin.com",
                Comment = "Opprettet av SeedData",
                CommentHeading = "Testkommentar",
                ProjectCycleTaskId = 1,
                Unique_IdString = "exampleprojectcycletaskcommentguid"
            };
            context.Add(initTaskComment);
            await context.SaveChangesAsync();
        }


    }
}
