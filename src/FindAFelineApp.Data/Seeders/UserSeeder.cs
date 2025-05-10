using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Data.Seeders
{
    public static class UserSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }

        private static async Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            var adminUser = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
            string adminPassword = "Admin#123";
            await SeedUser(adminUser, adminPassword, "Admin", userManager);

            var regularUser = new IdentityUser()
            {
                UserName = "user@user.com",
                Email = "user@user.user.com",
                EmailConfirmed = true
            };
            string regularPassword = "User#123";
            await SeedUser(regularUser, regularPassword, "User", userManager);
        }

        private static async Task SeedUser(IdentityUser user, string password, string roleName,
            UserManager<IdentityUser> userManager)
        {
            var userInfo = await userManager.FindByEmailAsync(user.Email);
            if (userInfo == null)
            {
                var created = await userManager
                    .CreateAsync(user, password);
                if (created.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User" };
            foreach (var role in roleNames)
            {
                bool roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
