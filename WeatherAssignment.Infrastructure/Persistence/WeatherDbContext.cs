using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Core;

namespace WeatherAssignment.Infrastructure.Persistence;

public class WeatherDbContext : DbContext
{
    public DbSet<Location> Locations { get; private set; } = null!;

    public DbSet<Forecast> Forecasts { get; private set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Location>(location =>
        {
            location.OwnsOne(x => x.Coordinates, coordinates =>
            {
                coordinates.HasIndex(c => new { c.Latitude, c.Longitude }).IsUnique();
            });
        });

        modelBuilder.Entity<Forecast>(forecast =>
        {
            forecast.HasOne(x => x.Location)
                    .WithMany()
                    .HasForeignKey("LocationId")
                    .OnDelete(DeleteBehavior.Cascade);

            forecast.OwnsMany(x => x.Values, forecastValue =>
            {
                forecastValue.WithOwner()
                             .HasForeignKey("ForecastId");

                forecastValue.OwnsOne(x => x.Temperature);

                forecastValue.OwnsOne(x => x.Precipitation);

                forecastValue.OwnsOne(x => x.Pressure);
            });
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Weather.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
