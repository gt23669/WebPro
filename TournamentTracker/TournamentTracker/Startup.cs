using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TournamentTracker.Models;

[assembly: OwinStartupAttribute(typeof(TournamentTracker.Startup))]
namespace TournamentTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            ApplicationDbContext dbContext = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@tournamenttracker.com";
                user.Email = "admin@tournamenttracker.com";

                string userPWD = "P@ssw0rd";

                var chkUser = userManager.Create(user, userPWD);
                
                if (chkUser.Succeeded)
                {
                    var roleAssignment = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Banned"))
            {
                var role = new IdentityRole();
                role.Name = "Banned";
                roleManager.Create(role);
            }
        }
    }
}
