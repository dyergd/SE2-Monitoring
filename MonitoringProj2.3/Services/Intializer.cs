﻿using Microsoft.AspNetCore.Identity;
using MonitoringProj2._3.Data;
using MonitoringProj2._3.Models.Entites;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Services
{
    public class Intializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Intializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            //RoleManager<IdentityRole> roleManager
            _db = db;
            _userManager = userManager;
            //_roleManager = roleManager;
        }

        public async Task SeedUsersAsync()
        {
            _db.Database.EnsureCreated();

            if (!_db.Roles.Any(r => r.Name == "Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }

            if (!_db.Roles.Any(r => r.Name == "User"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }
            if (!_db.Users.Any(u => u.UserName == "admin@test.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "admin@test.com",
                    UserName = "admin@test.com",
                };
                await _userManager.CreateAsync(user, "Pass1!");
                await _userManager.AddToRoleAsync(user, "Admin");
            }

        }
    }
}
