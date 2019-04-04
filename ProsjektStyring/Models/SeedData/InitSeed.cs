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
         * Initialize the db with some starter data
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
            // If we dont have a user, create a admin
            if (!context.Users.Any())
            {
                await CreateAdminAsync(context, uM);
            }
        }

        /**
         * Create a admin - Using my own email
         */
        private static async Task CreateAdminAsync(ApplicationDbContext context, UserManager<ApplicationUser> uM)
        {
            // Add a admin
            DateTime regdate = DateTime.Now;
            var admin = new ApplicationUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };

            await uM.CreateAsync(admin, "Password@123");
            context.SaveChanges();
            // Add admin to Administrator-role
            var aU = await uM.FindByEmailAsync(admin.Email);
            await uM.AddToRoleAsync(aU, RoleOptions.AdminRole);
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
    }
}
