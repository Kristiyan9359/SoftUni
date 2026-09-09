namespace CarMaintenanceTracker.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarMaintenanceTracker.Models;


public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; } = null!;
    public virtual DbSet<ServiceRecord> ServiceRecords { get; set; } = null!;
    public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;
}
