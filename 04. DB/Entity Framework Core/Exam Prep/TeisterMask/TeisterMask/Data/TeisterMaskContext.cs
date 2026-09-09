namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;
    using System.Reflection.Emit;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() 
        {
        }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) 
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<EmployeeTask> EmployeesTasks { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>(entity =>
            {
                entity.HasKey(et => new { et.EmployeeId, et.TaskId });
                entity.HasOne(et => et.Employee)
                      .WithMany(e => e.EmployeesTasks)
                      .HasForeignKey(et => et.EmployeeId);
                entity.HasOne(et => et.Task)
                      .WithMany(t => t.EmployeesTasks)
                      .HasForeignKey(et => et.TaskId);
            });
        }
    }
}