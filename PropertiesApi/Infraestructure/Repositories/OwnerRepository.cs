using Microsoft.EntityFrameworkCore;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Infraestructure.Persistence;
using PropertiesApi.Infraestructure.Repositories.Contracts;

namespace PropertiesApi.Infraestructure.Repositories
{
    public class OwnerRepository(RealEstateWriteContext realEstateWriteContext, RealEstateReadContext realEstateReadContext) : IOwnerRepository
    {
        /// <inheritdoc/>
        public async Task CreateOwnerPropertyAsync(OwnerProperty ownerProperty)
        {
            await realEstateWriteContext.Set<OwnerProperty>()
                                         .AddAsync(ownerProperty);
        }

        public async Task<OwnerProperty> GetOwnerPropertyById(long idOwnerProperty)
        {
            OwnerProperty ownerProperyFound = await realEstateReadContext.Set<OwnerProperty>().FirstOrDefaultAsync(p => p.IdOwner == idOwnerProperty);
            return ownerProperyFound;
        }
    }
}
