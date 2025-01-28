using Azure;
using Google.Apis.Storage.v1;
using MediatR;

using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateProperty
{
    public class CreatePropertyCommandHandler(IUnitOfWork unitOfWork
        )
        : IRequestHandler<CreatePropertyCommand, BaseResponse<String>>
    {
      
        public async Task<BaseResponse<String>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var newProperty = await RegisterProperty(request);
            if (!request.UrlImage.IsNullOrEmpty())
            {
                await RegisterPropertyImage(request, newProperty.IdProperty);
            }   
            return  new BaseResponse<String>(newProperty.IdOwner.ToString(),"");
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
            var ownerProperty = await unitOfWork._propertyRepository.AddAsync(newProperty);
            await unitOfWork.SaveChangesAsync();
            return ownerProperty;
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

            var propertyImage = await unitOfWork._propertyImageRepository.AddAsync(newPropertyImage);
            await unitOfWork.SaveChangesAsync();
            return propertyImage;
        }

    }
}