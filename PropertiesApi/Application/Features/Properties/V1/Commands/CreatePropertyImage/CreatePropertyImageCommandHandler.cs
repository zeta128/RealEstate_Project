using Azure;
using Google.Apis.Storage.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Services;
using PropertiesApi.Application.Common.Wrappers;
using static System.Net.Mime.MediaTypeNames;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg; // O el formato que necesites
using System.IO;
using Google.Cloud.Storage.V1;
using PropertiesApi.Infraestructure.Repositories;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreatePropertyImage
{
    public class CreatePropertyImageCommandHandler(IUnitOfWork unitOfWork
        )
        : IRequestHandler<CreatePropertyImageCommand, BaseResponse<String>>
    {
        /// <summary>
        /// Maneja la creación de un nuevo propietario.
        /// </summary>
        /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
        /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
        /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
        /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
        public async Task<BaseResponse<String>> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
        {          
           
            var imageProperty = await RegisterPropertyImage(request);
              
            return  new BaseResponse<String>(imageProperty.IdPropertyImage.ToString(),"");
        }
 
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