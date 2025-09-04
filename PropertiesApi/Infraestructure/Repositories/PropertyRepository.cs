using Ardalis.Specification.EntityFrameworkCore;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PropertiesApi.Application.Common.Specifications.Properties;
using PropertiesApi.Application.Features.Properties.V1.Queries;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Infraestructure.Persistence;
using PropertiesApi.Infraestructure.Repositories.Contracts;
using System.Threading;

namespace PropertiesApi.Infraestructure.Repositories
{
    public class PropertyRepository(RealEstateWriteContext realEstateWriteContext, RealEstateReadContext realEstateReadContext) : IPropertyRepository
    {
        /// <inheritdoc/>
        public async Task CreatePropertyAsync(Property property)
        {
            await realEstateWriteContext.Set<Property>()
                                         .AddAsync(property);
        }

        public async Task<(List<Property> listProperties, int totalRegistros)> GetListPropertiesAsyncBySpec(GetListPropertiesQuery getListPropertiesQuery, CancellationToken cancellationToken)
        {
            GetListPropertiesSpecification getListPropertiesSpecification = new GetListPropertiesSpecification
                (getListPropertiesQuery.NumberPage, getListPropertiesQuery.NumberRows, getListPropertiesQuery.Filters, getListPropertiesQuery.OrderingField, getListPropertiesQuery.SortDirection);
            List<Property> listProperties = await realEstateReadContext.Set<Property>().WithSpecification(getListPropertiesSpecification).ToListAsync();

            GetListPropertiesSpecification totalRegistrosSpec = new GetListPropertiesSpecification(null, null, getListPropertiesQuery.Filters, "", "");
            int totalRegistros = await realEstateReadContext.Set<Property>()
                                      .WithSpecification(totalRegistrosSpec)
                                      .CountAsync(cancellationToken);         
            return (listProperties, totalRegistros);
        }

        public async Task<Property> GetPropertyById(long idProperty)
        {
            return realEstateReadContext.Set<Property>().FirstOrDefaultAsync(p => p.IdProperty == idProperty).Result;
            
        }

        /// <inheritdoc/>

        public Task UpdateProperty(Property property)
        {
            realEstateWriteContext.Set<Property>().Update(property);
            return Task.CompletedTask;
        }
    }
}
