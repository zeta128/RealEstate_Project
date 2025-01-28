using Ardalis.Specification.EntityFrameworkCore;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;

namespace PropertiesApi.Infraestructure.Repositories
{
    public class Repository<TEntity>(RealEstateDBContext realEstateDbContext) : RepositoryBase<TEntity>(realEstateDbContext), IRepository<TEntity> where TEntity : class
    {
        public override async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await realEstateDbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public override Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            realEstateDbContext.Set<TEntity>().Update(entity);
            return Task.FromResult(entity);
        }

        public override Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            realEstateDbContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}   