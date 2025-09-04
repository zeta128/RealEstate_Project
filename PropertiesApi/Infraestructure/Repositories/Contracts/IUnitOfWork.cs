using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;

namespace PropertiesApi.Infraestructure.Repositories.Contracts
{
    public interface IUnitOfWork 
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
