using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringProj2._3.Data;
using MonitoringProj2._3.Models.Entites;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Services
{
    public class DbApplicationUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public DbApplicationUserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            //RoleManager<IdentityRole> roleManager
            dbContext = db;
            _userManager = userManager;
            //_roleManager = roleManager;
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;
        }


        public async Task<ApplicationUser> ReadAsync(string userName)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            user.Roles = await _userManager.GetRolesAsync(user);
            return user;
        }

        
        public async Task AssignUserToRoleAsync(string userName, string roleName)
        {
            var roleCheck = await _roleManager.RoleExistsAsync(roleName);
            if (!roleCheck)
            {
                // Create the role, if the role doesn't exist
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            var user = await ReadAsync(userName);
            if (user != null)
            {
                if (!user.HasRole(roleName))
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }

            }
        }
    }
}
