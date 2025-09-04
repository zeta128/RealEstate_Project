
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Infraestructure.Repositories;
using PropertiesApi.Infraestructure.Repositories.Contracts;

namespace PropertiesApi.Application.Features.Properties.V1.Commands.Handlers
{
    public class UpdatePropertyCommandHandler(IUnitOfWork unitOfWork, IPropertyRepository propertyRepository
        )
        : IRequestHandler<UpdatePropertyCommand, BaseResponse<string>>
    {

        public async Task<BaseResponse<string>> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var updateProperty = await UpdateProperty(request);
            await unitOfWork.SaveChangesAsync();
            return new BaseResponse<string>("id"+updateProperty.IdProperty.ToString(), "property updated successfully");
        }

        /// <summary>
        /// Updates an existing property in the system with the provided data.
        /// </summary>
        /// <param name="request">An object containing the necessary data to update the property.</param>
        /// <returns>Returns the updated property with the new information.</returns>
        private async Task<Property> UpdateProperty(UpdatePropertyCommand request)
        {
            Property propertyFind = await propertyRepository.GetPropertyById(request.IdProperty);
            if (propertyFind != null)
            {
                propertyFind.Price = request.Price;
                propertyFind.CodeInternal = request.CodeInternal;
                propertyFind.IdOwner = request.IdOwner!.Value;
                propertyFind.Name = request.Name;
                propertyFind.Address = request.Address != null ? request.Address: propertyFind.Address;
            }
            propertyRepository.UpdateProperty(propertyFind);         
            return propertyFind;
        }


    }
}