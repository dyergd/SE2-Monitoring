using MonitoringProj2._3.Models.Entites;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Services
{
    public interface IUserRepository
    {
        Task<ApplicationUser> ReadAsync(string userName); //method header for reading a user async
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password); //method header for creating a user async
        Task AssignUserToRoleAsync(string userName, string roleName); //method header for assigning a user a role async
    }
}
