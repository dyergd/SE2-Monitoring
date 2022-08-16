using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonitoringProj2._3.Models.Entites;
using MonitoringProj2._3.Models;
using MonitoringProj2._3.Models.ViewModels;
using MonitoringProj2._3.Data;

namespace Identity.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext _context;


        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userMgr, ApplicationDbContext context)
        {
            roleManager = roleMgr;
            userManager = userMgr;

            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Index() => View(roleManager.Roles);


        [Authorize(Roles = "Admin")]
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();

            //Original Generated Code
            //foreach (ApplicationUser user in userManager.Users) <-- Connection is already open here
            //{
            //    //SO this here doesn't work because this opens another connection
            //    //var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
            //    //list.Add(user);
            //}

            // New code to bypass two connections at once, which mysql does not support--Austin
            // Still a problem however, the users are not being added to the actual role
            foreach (var user in userManager.Users.ToList())
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    members.Add(user);
                }
                else
                {
                    nonMembers.Add(user);
                }
            }

            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }

        public async Task<ActionResult> UserListOfRoles()
        {

            var usersWithRoles = _context.Users.Select(i => new RoleListVM
            {
                Email = i.Email,
                FirstName = i.FirstName,
                LastName = i.LastName,
                //Role = (_context.UserRoles.Select

            });

            return View(usersWithRoles);
        }

    }
}