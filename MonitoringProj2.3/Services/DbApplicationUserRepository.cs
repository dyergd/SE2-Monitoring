using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringProj2._3.Data;
using MonitoringProj2._3.Models.Entites;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Services
{
    /// <summary>
    /// Class used for AspNetCore Identity
    /// Identity is the User management library for AspNetCore
    /// Manages Registration, Login, and Roles
    /// </summary>
    public class DbApplicationUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Constructor for DbApplicationUserRepository
        /// </summary>
        /// <param name="db">Database Context</param>
        /// <param name="userManager">User manager Object</param>
        public DbApplicationUserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            //RoleManager<IdentityRole> roleManager
            dbContext = db;
            _userManager = userManager;
            //_roleManager = roleManager;
        }

        /// <summary>
        /// Method for creating a new user
        /// </summary>
        /// <param name="user">ApplicationUser Object</param>
        /// <param name="password">Password for ApplicationUser</param>
        /// <returns>Created User</returns>
        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;
        }

        /// <summary>
        /// Reads the information for a particular User
        /// </summary>
        /// <param name="userName">username of user</param>
        /// <returns>The user with a particular username</returns>
        public async Task<ApplicationUser> ReadAsync(string userName)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            user.Roles = await _userManager.GetRolesAsync(user);
            return user;
        }

        /// <summary>
        /// Method for assigning a role to a user
        /// </summary>
        /// <param name="userName">username of the user</param>
        /// <param name="roleName">name of the role</param>
        /// <returns></returns>
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
