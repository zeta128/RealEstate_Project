
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;
using PropertiesApi.Domain.Options.Pagination;
using PropertiesApi.Application.Common.Specifications.Properties;
using PropertiesApi.Application.Features.Properties.V1.Queries.GetListProperties;
using Mapster;

namespace PropertiesApi.Application.Features.Owners.V1.Queries.GetListProperties
{
    public class GetListPropertiesQueryHandler(IUnitOfWork unitOfWork
        )
        : IRequestHandler<GetListPropertiesQuery, BaseResponse<Paged<GetListPropertiesResponse>>>
    {
        /// <summary>
        /// Maneja la creación de un nuevo propietario.
        /// </summary>
        /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
        /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
        /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
        /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
        public async Task<BaseResponse<Paged<GetListPropertiesResponse>>> Handle(GetListPropertiesQuery request, CancellationToken cancellationToken)
        {
            var getListPropertiesSpecification = new GetListPropertiesSpecification
                (request.NumberPage, request.NumberRows, request.Filters, request.OrderingField, request.SortDirection);
            List<Property> listProperties;
            listProperties = await unitOfWork._propertyRepository.ListAsync(getListPropertiesSpecification, cancellationToken);

            var listPropertiesMapped = await GetListPropertiesMapped(listProperties, cancellationToken);
            var propertiesMapped = new Paged<GetListPropertiesResponse>
            (listPropertiesMapped, await unitOfWork._propertyRepository.CountAsync(getListPropertiesSpecification, cancellationToken),
               request.NumberRows, request.NumberPage);


            return new BaseResponse<Paged<GetListPropertiesResponse>>(propertiesMapped);
        }

        /// <summary>
        /// Maps a list of properties to a list of response objects, enriching the properties with owner data.
        /// </summary>
        /// <param name="properties">A list of properties to be mapped.</param>
        /// <param name="cancellationToken">A token to monitor cancellation requests during the task execution.</param>
        /// <returns>Returns a list of GetListPropertiesResponse objects containing the mapped property and owner data.</returns>
        private async Task<IEnumerable<GetListPropertiesResponse>> GetListPropertiesMapped(List<Property> properties, CancellationToken cancellationToken)
        {
            var listaMapeada = new List<GetListPropertiesResponse>();
            
            foreach (var property in properties)
            {
                var respuesta = property.Adapt<GetListPropertiesResponse>();
                OwnerProperty ownerData = unitOfWork._ownerPropertyRepository.GetByIdAsync(property.IdOwner).Result!;
                respuesta.OwnerFullName = ownerData.FullName;
                listaMapeada.Add(respuesta);
            }
            return listaMapeada;
        }




    }
}