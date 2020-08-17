using Microsoft.EntityFrameworkCore;
using RaceApp.Models;

namespace RaceApp.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Inspection> Inspections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inspection>().ToTable("Inspections");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<Track>().ToTable("Tracks");
        }

    }
}