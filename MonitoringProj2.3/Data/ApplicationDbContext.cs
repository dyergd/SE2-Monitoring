using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonitoringProj2._3.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using MonitoringProj2._3.Models.ViewModels;

namespace MonitoringProj2._3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Visit> visits { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
    }
}
