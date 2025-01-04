using FlightsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightsAPI.Data
{
    public class FlightsDbContext(DbContextOptions<FlightsDbContext> options) : DbContext(options)
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>()
                .HasMany(a => a.Flights)
                .WithOne(f => f.Airline)
                .HasForeignKey(f => f.AirlineId);

            modelBuilder.Entity<Alliance>()
                .HasMany(al => al.Airlines)
                .WithOne(a => a.Alliance)
                .HasForeignKey(a => a.AllianceId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
