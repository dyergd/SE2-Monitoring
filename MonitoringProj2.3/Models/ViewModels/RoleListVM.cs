using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MonitoringProj2._3.Models.ViewModels

{
    /// <summary>
    /// The RoleListVM allows us to display information about a User and their Role
    /// </summary>
    public class RoleListVM
    {
        public string FirstName { get; set; }//The first name of the user
        public string LastName { get; set; }//The last name of the user
        public string Email { get; set; }//The email of the user
        public string Role { get; set; }//The role of the user

    }
}
