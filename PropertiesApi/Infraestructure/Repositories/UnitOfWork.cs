using Microsoft.EntityFrameworkCore;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;
using PropertiesApi.Infraestructure.Persistence;
using PropertiesApi.Infraestructure.Repositories.Contracts;

namespace PropertiesApi.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RealEstateWriteContext _realEstateDBContext;


        public UnitOfWork(
            RealEstateWriteContext realEstateDBContext)
        {
            _realEstateDBContext = realEstateDBContext;
        }
        public void Dispose()
        {
            _realEstateDBContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _realEstateDBContext.SaveChangesAsync(cancellationToken);
    }
}
