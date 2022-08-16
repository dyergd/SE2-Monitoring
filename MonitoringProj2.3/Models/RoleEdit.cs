using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MonitoringProj2._3.Models.Entites;

namespace Identity.Models
{
    /// <summary>
    /// RoleEdit essentiallys allows us to retrieve roles and associated members and non members
    /// </summary>
    public class RoleEdit
    {
        public IdentityRole Role { get; set; } //Retrieve the role
        public IEnumerable<ApplicationUser> Members { get; set; }//Retrieve members associated with that role
        public IEnumerable<ApplicationUser> NonMembers { get; set; }//Retrieve members not associated with that role
    }
}