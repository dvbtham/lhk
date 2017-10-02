using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using LeHuuKhoa.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeHuuKhoa.Persistence.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Persistence\Migrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            CreateUser(context);
        }
        private void CreateUser(ApplicationDbContext context)
        {
            if (context.Users.Any()) return;
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "admin",
                Email = "huu-khoa.le@univ-lille3.fr",
                EmailConfirmed = true,
                ImageUrl = "",
                Birthday = DateTime.ParseExact("15/09/1980", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Gender = "Nam",
                Name = "Lê Hữu Khóa",
                PhoneNumber = "01652130546"
            };

            if (manager.Users.Any()) return;
            manager.Create(user, "123123$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("huu-khoa.le@univ-lille3.fr");

            manager.AddToRoles(adminUser.Id, "Admin", "User");
        }

    }
}
