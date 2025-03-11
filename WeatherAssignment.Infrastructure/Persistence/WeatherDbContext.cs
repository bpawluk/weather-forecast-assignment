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
                forecastValue.HasKey(x => x.Id);

                forecastValue.WithOwner()
                             .HasForeignKey("ForecastId");

                forecastValue.Property(x => x.Temperature)
                             .HasConversion(temp => temp.Value, temp => new(temp));

                forecastValue.Property(x => x.Precipitation)
                             .HasConversion(prec => prec.Value, prec => new(prec));

                forecastValue.Property(x => x.Pressure)
                             .HasConversion(pres => pres.Value, pres => new(pres));
            });

            forecast.Property(x => x.Updated)
                    .IsConcurrencyToken();
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Weather.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
