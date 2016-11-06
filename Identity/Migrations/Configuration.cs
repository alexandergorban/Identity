using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "alex.gorban@outlook.com"))
            {
                // Seed Roles
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                // Seed Users
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "alex.gorban@outlook.com"};
                // Seed Users
                userManager.Create(user, "P@ssw0rd!");

                // Seed Roles
                roleManager.Create(new IdentityRole {Name = "admin"});
                userManager.AddToRole(user.Id, "admin");
            }

            //var hasher = new PasswordHasher();
            //context.Users.AddOrUpdate(u => u.UserName,
            //    new ApplicationUser { UserName = "alex.gorban@outlook.com", PasswordHash = hasher.HashPassword("P@ssw0rd!")});
        }
    }
}
