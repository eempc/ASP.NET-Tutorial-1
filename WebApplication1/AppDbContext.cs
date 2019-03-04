using Microsoft.EntityFrameworkCore;

// This class started off empty, even the inheritance was required

namespace WebApplication1 {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}