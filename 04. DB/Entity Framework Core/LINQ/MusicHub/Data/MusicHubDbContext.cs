namespace MusicHub.Data;

using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using System.Reflection.Emit;

public class MusicHubDbContext : DbContext
{
    public MusicHubDbContext()
    {
    }

    public MusicHubDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Song> Songs { get; set; } = null!;
    public virtual DbSet<Models.Album> Albums { get; set; } = null!;
    public virtual DbSet<Models.Performer> Performers { get; set; } = null!;
    public virtual DbSet<Models.Producer> Producers { get; set; } = null!;
    public virtual DbSet<Models.Writer> Writers { get; set; } = null!;
    public virtual DbSet<Models.SongPerformer> SongsPerformers { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<SongPerformer>()
           .HasKey(sp => new { sp.SongId, sp.PerformerId });
    }
}
