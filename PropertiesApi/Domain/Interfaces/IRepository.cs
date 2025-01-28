using Ardalis.Specification;

namespace PropertiesApi.Domain.Interfaces;

    public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
    }

