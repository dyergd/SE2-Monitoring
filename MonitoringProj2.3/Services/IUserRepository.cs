using MonitoringProj2._3.Models.Entites;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Services
{
    public interface IUserRepository
    {
        Task<ApplicationUser> ReadAsync(string userName);
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
        Task AssignUserToRoleAsync(string userName, string roleName);
    }
}
