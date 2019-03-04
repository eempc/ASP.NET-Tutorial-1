using Microsoft.EntityFrameworkCore;

// Database Step 2: Create this class
// This class started off empty, even the inheritance was required

namespace WebApplication1 {
    public class AppDbContext : DbContext {

        //This one has a constructor
        public AppDbContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}