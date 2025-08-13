using Microsoft.EntityFrameworkCore;
using CarMaintenanceTracker.Api.Models;

namespace CarMaintenanceTracker.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.VIN)
                .IsUnique();

            modelBuilder.Entity<Car>()
                .HasMany(c => c.MaintenanceRecords)
                .WithOne(m => m.Car)
                .HasForeignKey(m => m.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
