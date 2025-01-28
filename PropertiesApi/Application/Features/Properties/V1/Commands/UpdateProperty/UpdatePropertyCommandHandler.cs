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

namespace PropertiesApi.Application.Features.Owners.V1.Commands.UpdateProperty
{
    public class UpdatePropertyCommandHandler(IUnitOfWork unitOfWork
        )
        : IRequestHandler<UpdatePropertyCommand, BaseResponse<String>>
    {
        /// <summary>
        /// Maneja la creación de un nuevo propietario.
        /// </summary>
        /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
        /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
        /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
        /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
        public async Task<BaseResponse<String>> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var updateProperty = await UpdateProperty(request);
          
            return  new BaseResponse<String>(updateProperty.IdProperty.ToString(),"");
        }
 

        private async Task<Property> UpdateProperty(UpdatePropertyCommand request)
        {
            Property propertyFind = await unitOfWork._propertyRepository.GetByIdAsync(request.IdProperty);
            if (propertyFind != null)
            {
                propertyFind.Price = request.Price;
                propertyFind.CodeInternal = request.CodeInternal;
                propertyFind.IdOwner = request.IdOwner!.Value;
            }
            
            await unitOfWork._propertyRepository.UpdateAsync(propertyFind);
            await unitOfWork.SaveChangesAsync();
            return propertyFind;
        }
        

    }
}