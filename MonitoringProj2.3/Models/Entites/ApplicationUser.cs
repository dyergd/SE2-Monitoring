using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MonitoringProj2._3.Models.Entites
{
    /// <summary>
    /// The Application User entity represents a User of our application implementing default Identity functions
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } //The FirstName of the User
        public string LastName { get; set; } //The LastName of the User

        [NotMapped]
        public ICollection<string> Roles { get; set; } // The Roles the User belongs to

        /// <summary>
        /// Constructor for the ApplicationUser's Roles list
        /// </summary>
        public ApplicationUser()
        {
            Roles = new List<string>(); 
        }

        /// <summary>
        /// Boolean method to check if a User has a specific role or not
        /// </summary>
        /// <param name="roleName">The role to check for</param>
        /// <returns>True or false</returns>
        public bool HasRole(string roleName)
        {
            return Roles.Any(r => r == roleName);
        }
    }
}
