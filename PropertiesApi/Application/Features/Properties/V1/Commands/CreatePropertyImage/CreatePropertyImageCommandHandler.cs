
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;
using PropertiesApi.Application.Features.Owners.V1.Commands.CreateProperty;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreatePropertyImage
{
    public class CreatePropertyImageCommandHandler(IUnitOfWork unitOfWork
        )
        : IRequestHandler<CreatePropertyImageCommand, BaseResponse<String>>
    {
        
        public async Task<BaseResponse<String>> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
        {          
           
            var imageProperty = await RegisterPropertyImage(request);
              
            return  new BaseResponse<String>(imageProperty.IdPropertyImage.ToString(),"");
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

            var propertyImage = await unitOfWork._propertyImageRepository.AddAsync(newPropertyImage);
            await unitOfWork.SaveChangesAsync();
            return propertyImage;
        }

    }
}