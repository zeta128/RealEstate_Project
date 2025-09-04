using Azure;
using Google.Apis.Storage.v1;
using MediatR;

using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using PropertiesApi.Infraestructure.Repositories.Contracts;
using PropertiesApi.Infraestructure.Repositories;

namespace PropertiesApi.Application.Features.Properties.V1.Commands.Handlers
{
    public class CreatePropertyCommandHandler(IUnitOfWork unitOfWork, IPropertyRepository propertyRepository, IPropertyImageRepository propertyImageRepository
        )
        : IRequestHandler<CreatePropertyCommand, BaseResponse<string>>
    {

        public async Task<BaseResponse<string>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var newProperty = await RegisterProperty(request);
            if (!request.UrlImage.IsNullOrEmpty())
            {
                await RegisterPropertyImage(request, newProperty.IdProperty);
            }
            await unitOfWork.SaveChangesAsync();
            return new BaseResponse<string>("id" + newProperty.IdProperty.ToString(), "Property creation done");
        }

        /// <summary>
        /// Registers a new property in the system using the provided data.
        /// </summary>
        /// <param name="request">An object containing the necessary data to create the property.</param>
        /// <returns>The newly created property.</returns>
        private async Task<Property> RegisterProperty(CreatePropertyCommand request)
        {
            Property newProperty = new Property();
            newProperty.Name = request.Name;
            newProperty.Address = request.Address;
            newProperty.Price = request.Price;
            newProperty.CodeInternal = request.CodeInternal;
            newProperty.Year = request.Year;
            newProperty.IdOwner = request.IdOwner;
            await propertyRepository.CreatePropertyAsync(newProperty);          
            return newProperty;
        }

        /// <summary>
        /// Registers a new property image in the system using the provided data.
        /// </summary>
        /// <param name="request">An object containing the necessary data to create the property image.</param>
        /// <param name="idProperty">The identifier of the property to associate with the image.</param>
        /// <returns>The newly created property image.</returns>
        private async Task<PropertyImage> RegisterPropertyImage(CreatePropertyCommand request, long idProperty)
        {
            PropertyImage newPropertyImage = new PropertyImage();
            newPropertyImage.IdProperty = idProperty;
            newPropertyImage.FileUrl = request.UrlImage;
            newPropertyImage.Enabled = true;
            await propertyImageRepository.CreatePropertyImageAsync(newPropertyImage);     
            return newPropertyImage;
        }

    }
}