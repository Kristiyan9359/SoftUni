using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data;

public class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }
    public HospitalContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> Patients { get; set; } = null!;
    public virtual DbSet<Visitation> Visitations { get; set; } = null!;
    public virtual DbSet<Diagnose> Diagnoses { get; set; } = null!;
    public virtual DbSet<Medicament> Medicaments { get; set; } = null!;
    public virtual DbSet<PatientMedicament> PatientsMedicaments { get; set; } = null!;
    public virtual DbSet<Doctor> Doctors { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientMedicament>()
            .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

        modelBuilder.Entity<PatientMedicament>()
            .HasOne(pm => pm.Patient)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(pm => pm.PatientId);

        modelBuilder.Entity<PatientMedicament>()
            .HasOne(pm => pm.Medicament)
            .WithMany(m => m.Prescriptions)
            .HasForeignKey(pm => pm.MedicamentId);
    }
}
