using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase.Data;

public class SalesContext : DbContext
{
    public SalesContext()
    {
    }
    public SalesContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Product> Products { get; set; } = null!;
    public virtual DbSet<Models.Customer> Customers { get; set; } = null!;
    public virtual DbSet<Models.Store> Stores { get; set; } = null!;
    public virtual DbSet<Models.Sale> Sales { get; set; } = null!;



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer("Server=.;Database=SalesDatabase;Integrated Security=True;");
        }
    }
}
