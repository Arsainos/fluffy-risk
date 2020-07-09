using Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Data
{
    public class ApplicationIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options) : base(options) { }
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Добаление ролей
            foreach (string role in new[] { "Admin", "Manager", "User" })
                if (await roleManager.FindByNameAsync(role) == null)
                    await roleManager.CreateAsync(new IdentityRole(role));

            // Добавление пользователей
            var users = new[]
            {
                (id: "1", Name: "IvanovII", Password:"111", Roles: new List<string> { "Admin" }),
                (id: "2", Name: "PetrovPP", Password:"222", Roles: new List<string> { "Manager" }),
                (id: "3", Name: "SidorovSS", Password:"333", Roles: new List<string> { "User" }),
                (id: "4", Name: "SemionovSS", Password:"444", Roles: new List<string> { "Admin", "Manager" })
            };

            foreach (var user in users)
            {
                if (await userManager.FindByNameAsync(user.Name) != null)
                    continue;

                ApplicationUser applicationUser = new ApplicationUser {Id = user.id, UserName = user.Name, PasswordHash = user.Password };
                IdentityResult result = await userManager.CreateAsync(applicationUser);

                if (result.Succeeded)
                    foreach (var role in user.Roles)
                        await userManager.AddToRoleAsync(applicationUser, role);
            }
        }
    }
}
