using CLDV6211_POE_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace CLDV_POE_P1.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    // Define your DbSets (tables) here
    public DbSet<UserTable> UserTables { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}
