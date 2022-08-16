using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace MonitoringProj.Services
{
    public class ApplicationDbContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Visit> visits { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Set server version
            var serverVersion = new MySqlServerVersion(new Version(10, 5, 12));
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, serverVersion);
        }

    }
}
