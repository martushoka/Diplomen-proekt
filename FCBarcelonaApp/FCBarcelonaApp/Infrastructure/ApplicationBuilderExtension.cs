using FCBarcelonaApp.Data;
using FCBarcelonaApp.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataMyTeam = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedMyTeams(dataMyTeam);

            var dataTeam = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedTeams(dataTeam);


            return app;
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.UserName = "admin";
                user.PhoneNumber = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync
                (user, "Admin123456");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private static void SeedMyTeams(ApplicationDbContext dataMyTeam)
        {
            if (dataMyTeam.MyTeams.Any())
            {
                return;
            }
            dataMyTeam.MyTeams.AddRange(new[]
            {
                //new MyTeam {TeamName="Barcelona",Picture="https://www.pngitem.com/pimgs/m/83-830746_fc-barcelona-old-logo-hd-png-download.png" }
                new MyTeam {MyTeamName="Barcelona",Picture="/Images/Team/barselona.png" }
            });
            dataMyTeam.SaveChanges();
        }
        private static void SeedTeams(ApplicationDbContext dataTeam)
        {
            if (dataTeam.Teams.Any())
            {
                return;
            }
            dataTeam.Teams.AddRange(new[]
            {
                new Team {TeamName="Arsenal",Picture="/Images/Team/arsenal.png"},
                new Team {TeamName="Juventus",Picture="/Images/Team/uventus.jpg"},
                new Team {TeamName="RealMadrid",Picture="/Images/Team/real.png"},
                new Team {TeamName="Sevilla",Picture="/Images/Team/real.png"},
                new Team {TeamName="BayernMunich",Picture="/Images/Team/real.png"},
                new Team {TeamName="AtleticoMadrid",Picture="/Images/Team/real.png"},



            });
            dataTeam.SaveChanges();
        }


    }
}
