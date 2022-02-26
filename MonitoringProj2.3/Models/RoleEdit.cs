using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MonitoringProj2._3.Models.Entites;

namespace Identity.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
}