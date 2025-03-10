using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Core.Interface;

namespace WeatherAssignment.Infrastructure.Persistence;

internal class UnitOfWork<TDbContext>(TDbContext dbContext) : IUnitOfWork where TDbContext : DbContext
{
    private readonly TDbContext _dbContext = dbContext;

    public DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return _dbContext.Set<TEntity>();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}