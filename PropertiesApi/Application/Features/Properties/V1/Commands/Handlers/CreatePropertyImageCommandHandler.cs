
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Infraestructure.Repositories.Contracts;

namespace PropertiesApi.Application.Features.Properties.V1.Commands.Handlers
{
    public class CreatePropertyImageCommandHandler(IUnitOfWork unitOfWork, IPropertyImageRepository propertyImageRepository
        )
        : IRequestHandler<CreatePropertyImageCommand, BaseResponse<string>>
    {

        public async Task<BaseResponse<string>> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
        {

            var imageProperty = await RegisterPropertyImage(request);
            await unitOfWork.SaveChangesAsync();
            return new BaseResponse<string>(imageProperty.IdPropertyImage.ToString(), "Propery image upload done");
        }

        /// <summary>
        /// Registers a new property image in the system with the provided data.
        /// </summary>
        /// <param name="request">An object containing the necessary data to register the property image.</param>
        /// <returns>Returns the registered property image with the associated information.</returns>
        private async Task<PropertyImage> RegisterPropertyImage(CreatePropertyImageCommand request)
        {
            PropertyImage newPropertyImage = new PropertyImage();
            newPropertyImage.IdProperty = request.IdProperty;
            newPropertyImage.FileUrl = request.UrlImage;
            newPropertyImage.Enabled = true;
            await propertyImageRepository.CreatePropertyImageAsync(newPropertyImage);           
            return newPropertyImage;
        }

    }
}