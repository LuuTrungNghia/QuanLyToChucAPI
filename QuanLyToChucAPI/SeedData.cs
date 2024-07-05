using Microsoft.AspNetCore.Identity;
using QuanLyToChucAPI.Models;
using System.Threading.Tasks;

namespace QuanLyToChucAPI
{
    public class SeedData
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedData(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            var roles = new[]
            {
            new { Name = "admin", NormalizedName = "ADMIN" },
            new { Name = "watch", NormalizedName = "WATCH" }
        };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role.Name))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role.Name.ToUpper()));
                }
            }

            var adminUser = await _userManager.FindByNameAsync("admin");

            if (adminUser == null)
            {
                adminUser = new SystemUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    Address = "Admin Address",
                    FullName = "admin",
                };

                var result = await _userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "admin");
                }
            }
        }
    }
}
