using PropertiesApi.Domain.Entities;

namespace PropertiesApi.Infraestructure.Repositories.Contracts
{
    public interface IOwnerRepository
    {
        Task CreateOwnerPropertyAsync(OwnerProperty ownerProperty);
        Task<OwnerProperty> GetOwnerPropertyById(long idOwnerProperty);
    }
}
