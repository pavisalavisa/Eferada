using Eferada.Data.DatabaseContext;
using Eferada.Data.Model.Entities.Identity;
using Eferada.Data.Model.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace Eferada.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EferadaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EferadaDbContext context)
        {
            Task.Run(async () => await SeedAsync(context).ConfigureAwait(false)).Wait();
        }

        private async Task SeedAsync(EferadaDbContext context)
        {
            //await SeedRoles(context).ConfigureAwait(false);
            //await SeedUsers(context).ConfigureAwait(false);

            //await context.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task SeedRoles(EferadaDbContext context)
        {
            //Get roles from enum
            var roles = Enum.GetNames(typeof(Roles))
                .ToDictionary(item => item, item => Convert.ToInt32(Enum.Parse(typeof(Roles), item)));

            foreach (var role in roles)
            {
                if (context.Roles.Any(r => r.Name == role.Key))
                {
                    continue;
                }

                var store = new RoleStore<ApplicationRole, int, ApplicationUserRole>(context);
                var manager = new RoleManager<ApplicationRole, int>(store);
                var applicationRole = new ApplicationRole
                {
                    Id = role.Value,
                    Name = role.Key
                };

                await manager.CreateAsync(applicationRole).ConfigureAwait(true);
            }
        }

        private async Task SeedUsers(EferadaDbContext context)
        {
            //await SeedAdmin(context).ConfigureAwait(true);
            const string studentRoleName = nameof(Roles.Student);
            const string studentUserName = "SomeStudent";
            const string studentEmail = "specy.specimen@gmail.com";
            if (!context.Users.Any(x => x.UserName == studentUserName))
            {
                var store = new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context);
                var manager = new UserManager<ApplicationUser, int>(store);
                var user = new ApplicationUser
                {
                    UserName = studentUserName,
                    Email = studentEmail,
                    FirstName = "Specy",
                    LastName = "Specimen",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PhoneNumber="098123123"
                };

                await manager.CreateAsync(user, "student.123").ConfigureAwait(false);
                //await manager.AddToRoleAsync(user.Id, studentRoleName).ConfigureAwait(false);
            }
            //await SeedStundent(context).ConfigureAwait(true);
            //const string adminRoleName = nameof(Roles.Admin);
            //const string adminUserName = "MainAdministrator";
            //const string adminEmail = "kristicevic.antonio@gmail.com";
            //if (!context.Users.Any(x => x.UserName == adminUserName))
            //{
            //    var store = new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context);
            //    var manager = new UserManager<ApplicationUser, int>(store);
            //    var user = new ApplicationUser
            //    {
            //        UserName = adminUserName,
            //        Email = adminEmail,
            //        FirstName = "Antonio",
            //        LastName = "Kristicevic",
            //        EmailConfirmed = true
            //    };

            //    await manager.CreateAsync(user, "admin.123").ConfigureAwait(true);
            //    await manager.AddToRoleAsync(user.Id, adminRoleName).ConfigureAwait(true);
            //}

        }

        private async  Task SeedStundent(EferadaDbContext context)
        {
            const string studentRoleName = nameof(Roles.Student);
            const string studentUserName = "SomeStudent";
            const string studentEmail = "specy.specimen@gmail.com";
            if (!context.Users.Any(x => x.UserName == studentUserName))
            {
                var store = new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context);
                var manager = new UserManager<ApplicationUser, int>(store);
                var user = new ApplicationUser
                {
                    UserName = studentUserName,
                    Email = studentEmail,
                    FirstName = "Specy",
                    LastName = "Specimen",
                    EmailConfirmed = true
                };

                await manager.CreateAsync(user, "student.123").ConfigureAwait(true);
                await manager.AddToRoleAsync(user.Id, studentRoleName).ConfigureAwait(true);
            }
        }

        private static async Task SeedAdmin(EferadaDbContext context)
        {
            const string adminRoleName = nameof(Roles.Admin);
            const string adminUserName = "MainAdministrator";
            const string adminEmail = "kristicevic.antonio@gmail.com";
            if (!context.Users.Any(x => x.UserName == adminUserName))
            {
                var store = new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context);
                var manager = new UserManager<ApplicationUser, int>(store);
                var user = new ApplicationUser
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    FirstName = "Antonio",
                    LastName = "Kristicevic",
                    EmailConfirmed = true
                };

                await manager.CreateAsync(user, "admin.123").ConfigureAwait(true);
                await manager.AddToRoleAsync(user.Id, adminRoleName).ConfigureAwait(true);
            }
        }
    }
}

