using Microsoft.EntityFrameworkCore;

namespace WeatherAssignment.Core.Interface;

public interface IUnitOfWork
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task SaveChanges(CancellationToken cancellationToken);
}