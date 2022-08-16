using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    /// <summary>
    /// RoleModification allows us to retrieve and modify Role values
    /// </summary>
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }//The name of the Role

        public string RoleId { get; set; }//The ID of the Role

        public string[] AddIds { get; set; }//The additions to the Role

        public string[] DeleteIds { get; set; }//The deletions from the Role
    }
}