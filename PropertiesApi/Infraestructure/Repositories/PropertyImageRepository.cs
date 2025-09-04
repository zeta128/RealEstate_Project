using PropertiesApi.Domain.Entities;
using PropertiesApi.Infraestructure.Persistence;
using PropertiesApi.Infraestructure.Repositories.Contracts;

namespace PropertiesApi.Infraestructure.Repositories
{
    public class PropertyImageRepository(RealEstateWriteContext realEstateWriteContext) : IPropertyImageRepository
    {
        /// <inheritdoc/>
        public async Task CreatePropertyImageAsync(PropertyImage propertyImage)
        {
            await realEstateWriteContext.Set<PropertyImage>()
                                        .AddAsync(propertyImage);
        }
    }
}
