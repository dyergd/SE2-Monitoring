using Microsoft.EntityFrameworkCore;

namespace MonitoringProj.Services
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Visit> visits { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<VisitClicks> VisitClicks { get; set; } = null!;
        public DbSet<VisitResponse> VisitResponses { get; set; } = null!;
    }
}
