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

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateOwner
{
    /// <summary>
    /// Maneja la creación de un nuevo propietario.
    /// </summary>
    /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
    /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
    /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
    /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
    public class CreateOwnerCommandHandler(IUnitOfWork unitOfWork
        )
        : IRequestHandler<CreateOwnerCommand, BaseResponse<String>>
    {
        /// <summary>
        /// Maneja la creación de un nuevo propietario.
        /// </summary>
        /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
        /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
        /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
        /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
        public async Task<BaseResponse<String>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var newOwner = await RegisterOwner(request);
            await unitOfWork.SaveChangesAsync();     
            return  new BaseResponse<String>(newOwner.IdOwner.ToString());

        }
 

        private async Task<OwnerProperty> RegisterOwner(CreateOwnerCommand request)
        {      
            OwnerProperty newOwner = new OwnerProperty();
            newOwner.FullName = request.FullName;
            newOwner.Address = request.Address;
            newOwner.Photo = request.UrlPhoto;
            newOwner.Birthday = request.Birthday;
             var ownerProperty = await unitOfWork._ownerPropertyRepository.AddAsync(newOwner);
            return ownerProperty;
        }

    }
}