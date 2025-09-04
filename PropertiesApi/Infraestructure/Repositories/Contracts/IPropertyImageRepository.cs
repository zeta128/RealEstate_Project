using PropertiesApi.Domain.Entities;

namespace PropertiesApi.Infraestructure.Repositories.Contracts
{
    public interface IPropertyImageRepository
    {
        Task CreatePropertyImageAsync(PropertyImage propertyImage);
    }
}
