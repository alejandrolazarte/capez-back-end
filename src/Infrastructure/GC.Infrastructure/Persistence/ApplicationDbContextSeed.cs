using CG.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CG.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<SystemAccount> userManager)
        {
            var user = new SystemAccount
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com"
            };

            if (userManager.Users.All(u => u.UserName != user.UserName))
            {
                await userManager.CreateAsync(user, "Admin1234.");
            }
        }
    }
}
