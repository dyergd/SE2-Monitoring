using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MonitoringProj2._3.Models.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public ICollection<string> Roles { get; set; }

        public ApplicationUser()
        {
            Roles = new List<string>(); 
        }

        public bool HasRole(string roleName)
        {
            return Roles.Any(r => r == roleName);
        }
    }
}
