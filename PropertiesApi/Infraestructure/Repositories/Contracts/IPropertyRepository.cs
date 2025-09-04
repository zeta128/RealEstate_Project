using PropertiesApi.Application.Common.Specifications.Properties;
using PropertiesApi.Application.Features.Properties.V1.Queries;
using PropertiesApi.Domain.Entities;

namespace PropertiesApi.Infraestructure.Repositories.Contracts
{
    public interface IPropertyRepository
    {
        Task CreatePropertyAsync(Property property);
        Task UpdateProperty(Property property);
        Task<Property> GetPropertyById(long idProperty);
        Task<(List<Property> listProperties, int totalRegistros)> GetListPropertiesAsyncBySpec(GetListPropertiesQuery getListPropertiesQuery, CancellationToken cancellationToken);
    }
}
